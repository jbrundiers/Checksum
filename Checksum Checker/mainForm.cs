using System;
using System.ComponentModel;

using System.Text;
using System.Windows.Forms;

using System.IO;						// For use in using the Stream class to read the users selected file
using System.Security.Cryptography;		// For use to gain access to the Hash, MD5 and SHA1 classes
using System.Text.RegularExpressions;	// For use in checking the validity of hashes to be compared

namespace Checksum {

	public partial class mainForm : Form
    {
				
		
		string filePath;		// Global String variable to place the file path into (in this case the entire file path also)

		string computedHash; // Global Strings to store the relevant computed hash values

		static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" }; // string array of byte size suffixes 
                                                                                                             


        long totalBytesRead = 0;    // Global variable to store the total count of the bytes read in the computeFileHash_DoWork functions do-while loop
        long totalBytesToRead = 0;    

        OpenFileDialog openFD = new OpenFileDialog();		// Creates a global new OpenFileDialog instance openFD

		public mainForm() {
			// Form object is created

			InitializeComponent();          // Call for initialising the form

            // Set the Form Title Text plus the current version of the program
            this.Text = "Checksum " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            
            textboxHashToCompare.Text = "";
            textboxComputedHash.Text = "";
            buttonCompareHash.Enabled = false;
            rbtnMD5.Checked = true;
            rbtnSHA1.Checked = false;

        }

        /// <summary>
        /// Checks via regex if the given Hexadecimal hash is valid
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="result"></param>
        /// <returns></returns>
		private bool isHash(string hash, bool result = false)
        {
			Regex regex = new Regex("[0-9a-fA-F]{32}");         // Create a new Regex object with the regex pattern
                                                                
            Match match = regex.Match(hash);                    // Create a new instance of match and check the regex pattern against the submitted Hexadecimal hash
                                                                
            if (match.Success)                                  // If the match is a success change the result to true
                result = true;
			
            return result;
		}

        /// <summary>
        /// A function that provides easy string conversion for byte sizes, eg. bytes to KB, etc...
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		private static string SizeSuffix(Int64 value)
        {
			if (value < 0) { return "-" + SizeSuffix(-value); }
			if (value == 0) { return "0.0 bytes"; }

			int mag = (int)Math.Log(value, 1024);
			decimal adjustedSize = (decimal)value / (1L << (mag * 10));

			return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
		}

        /// <summary>
        /// Takes the created hash, as a byte array, and returns the hash, converted into a string
        /// </summary>
        /// <param name="hashBytes"></param>
        /// <returns></returns>
		private static string makeHashString(byte[] hashBytes)
        {
            // Creates a new StringBuilder, hash, with the initial capactity of 32, which is the length of an hash
            // Length  = 32
            // StringBuilder hash = new StringBuilder(32);
            StringBuilder hash = new StringBuilder();
            
            foreach (byte b in hashBytes)
            {
				// Foreach of the bytes in hashBytes as new variable b
				hash.Append(b.ToString("x2"));
				// Convert the byte into a lowercase hexidecimal and append that to the StringBuilder, hash
			}

			return hash.ToString();
		}

        /// <summary>
        /// Place all things that need to be reset when the user calculates a new hash
        /// </summary>
		private void resetForm()
        {
		    totalBytesRead = 0;                                 // Reset the total bytes read amount - crucial that this is done
            
            computedHash = "";                                  // Reset the computed hash variables
            textboxComputedHash.Text = "";                      // Reset the computed hash textbox
            textBoxCurrentByteCount.Text = "0 Bytes";           // Reset the current byte count 
            buttonCompareHash.Enabled = false;
            return;
		}

        /// <summary>
        /// Actions for when the button, buttonOpenFileDialog, is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFileDialog_Click(object sender, EventArgs e)
        {
		    if (openFD.ShowDialog() == DialogResult.OK)
            {
                // user has selected and hit the OK button in the OpenFileDialog
                // Set the text of the textboxFilePath to the user selected file path
                // also set the (string) variable filePath to that of the file path
                textboxFilePath.Text = filePath = openFD.FileName;

                totalBytesToRead = new System.IO.FileInfo(filePath).Length;

                textBoxTotalByteCount.Text = SizeSuffix(totalBytesToRead);

            }
            return;
        }

        /// <summary>
        /// Actions for when the button, buttonGetHash, is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void buttonGetHash_Click(object sender, EventArgs e)
        {

			if (filePath != null)                           // If filePath is set, meaning the user has selected a file to hash, then continue
            {
                if (!computeFileHash.IsBusy)                // If the worker isn't already processing a computeFileHash task, then continue
                { 
					resetForm();
					
					buttonCalculateHash.Enabled = false;          // Disable and hide the get hash button
                    buttonCalculateHash.Visible = false;
					
					buttonCancelHash.Enabled = true;        // Enable and show the cancel hash button
                    buttonCancelHash.Visible = true;

                    //
                    // Proceed to the computeFileHash_DoWork function below to start computing the relevant hash on a new Thread
                    //
                    computeFileHash.RunWorkerAsync();
					

					pollCurrentBytesCompleted.Start();  //	Start a timer in which the totalBytesRead is polled and the tool strip label,
                                                        //	toolstripProgressCurrentByteCount, text is updated to reflect the new value
                }
				else {
					MessageBox.Show("Please wait until the current hash has finished calculating.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					// If the worker is already processing a task, show the user an error
				}

			}
			else {
				MessageBox.Show("Please select a file first!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				// If filePath is not set then show the user an error, as they have not selected a file to hash
			}

			return;
		}

		private void buttonCancelHash_Click(object sender, EventArgs e) {
			// Actions for when the button, buttonCancelHash, is clicked

			if (computeFileHash.IsBusy) {
				// If there is a running operation for the background worker computeFileHash...

				computeFileHash.CancelAsync();
				// ... Cancel the hash calculation operation
			}
			else {
				MessageBox.Show("No hash calculation is currently running to terminate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				// Otherwise return an error message stating that the user cannot terminate an operation that does not exist!
			}

			return;
		}
        /// <summary>
        /// Actions for when the button, buttonCompareHash, is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCompareHash_Click(object sender, EventArgs e)
        {
            if (isHash(textboxHashToCompare.Text))
            {
                // Send the content of the text box, textboxHashToCompare, to the isHash function to check if the user
                // has entered a valid hash
                if (string.Equals(textboxHashToCompare.Text, computedHash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Success!\nComputed and Compared Hashes are the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Warning!\nComputed and Compared Hashes are NOT the same.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Not a valid Hexadecimal Hash. Please try again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
    }

        /// <summary>
        /// Start the process of computing the hash in the background
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computeFileHash_DoWork(object sender, DoWorkEventArgs e)
        {
            HashAlgorithm hasher;

            byte[] buffer;              // New byte array for the buffer to read parts of the user selected file into and hash those parts

            int bytesRead;              // The amount of bytes read as the loop iterates below
     
            long size;                  // The size of the users file to be hashed in bytes

            using (Stream file = File.OpenRead(filePath))
            {
                // Create a new Stream, file, from the users selected file from the global filePath variable

                size = file.Length;

                if (rbtnMD5.Checked)
                    hasher = MD5.Create();
                else
                    hasher = SHA1.Create();


                //using (HashAlgorithm hasher = MD5.Create())
                using (hasher)
                {
                    // Create a new HashAlgorithm, hasher, of the requested type to do the hashing of the users selected file
                    do
                    {
                        // Checks if the background worker, computeFileHash, has been told to cancel
                        if (computeFileHash.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        buffer = new byte[4096];                                // Initialise the buffer to a new byte array, to the size of 4096 bytes
                       
                        bytesRead = file.Read(buffer, 0, buffer.Length);        // fill the buffer 
                        
                        totalBytesRead += bytesRead;                            // Update the total for the amount of bytes read so far
                    
                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);   // Creates the hash value for the bytes just read into the buffer
                        
                        //computeFileHash.ReportProgress((int)((double)totalBytesRead / size * 100));
                        // ReportProgress calls the background workers ProgressChanged function, in this case the
                        //	computeFileHash_ProgressChanged function below with the supplied argument being
                        //	an integer of the percentage of the file currently being hashed
                    }
                    while (bytesRead != 0);
                    // Keep looping over the files buffer until the bytesRead count equals zero, meaning there are no more bytes to be read
                    //	and the file has been processed and can move on to the full hash generation next

                    hasher.TransformFinalBlock(buffer, 0, 0);
                    // Transform the final block, put all the hashes together to make the full hash
                    //	Arg1 - the input buffer - so just pass the buffer, buffer, again
                    //	Arg2 - the input buffer byte offset - again, do not need the offset, start at the beginning, so set to zero
                    //	Arg3 - the byte count - the amount of bytes from buffer to be read, in this case zero, as we didn't read any new bytes

                    e.Result = makeHashString(hasher.Hash);
                    // Set the Result argument of the DoWorkEventArgs to the computed hash value
                    //	It is run through the custom makeHashString function to first convert the computed byte
                    //	array into a string before sending it on its merry way

                } // end using

            }
		}

		/// <summary>
        /// Called when the backgroundWorker has finished the given task; be it successfull, cancelled or errored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void computeFileHash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			if (e.Error != null)            // Operation errored
            {
                MessageBox.Show("Error:\n\n" + e.Error.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (e.Cancelled)           // Operation was cancelled
            { 
                textboxComputedHash.Text = "Hash calculation cancelled by user.";
			}
            else                            // Operation completed successfully
            {
                // Set the text of the textbox to the computed hash value
                textboxComputedHash.Text = computedHash = e.Result.ToString();
                progressBarBytesRead.Value = 100;
            }
			
			
			pollCurrentBytesCompleted.Stop();
			// Stop the polling timer of the totalBytesRead variable

			buttonCancelHash.Enabled = false;
			buttonCancelHash.Visible = false;
			// Disable & hide buttonCancelHash

			buttonCalculateHash.Enabled = true;
			buttonCalculateHash.Visible = true;
            // Enable & show buttonGetHash

            buttonCompareHash.Enabled = true;
            // Enable CompareHash

            textBoxCurrentByteCount.Text = SizeSuffix(totalBytesRead);
            // Update the total for the amount of bytes read for the user to see on the tool strip label, toolstripProgressCurrentByteCount
        }

        /// <summary>
        /// Polls the totalBytesRead variable and updates the tool strip label, toolstripProgressCurrentByteCount, to reflect the new value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void pollCurrentBytesCompleted_Tick(object sender, EventArgs e)
        {
            
            textBoxCurrentByteCount.Text = SizeSuffix(totalBytesRead); // read and update display with the total for the amount of bytes read

            //progressBar1.Maximum = 100;
            //progressBar1.Step = 1;

            int iPercent = Convert.ToInt16( Convert.ToDouble(totalBytesRead) / Convert.ToDouble(totalBytesToRead ) * 100);

            progressBarBytesRead.Value = iPercent;
        }

        /// <summary>
        /// exitToolStripMenuIte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// aboutToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instantiate window
            AboutBox dlg = new AboutBox();

            dlg.StartPosition = FormStartPosition.CenterParent; 

            // Show window modally
            // NOTE: Returns only when window is closed
            dlg.ShowDialog();

        }

       
    }
}
