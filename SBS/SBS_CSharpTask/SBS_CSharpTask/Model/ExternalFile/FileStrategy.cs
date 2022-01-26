using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SBS_CSharpTask.Model.ExternalFile
{
    public interface FileStrategy
    {
		/// <summary>
		/// Create an empty file.
		/// </summary>
		/// <returns></returns>
		bool createFile();

		/// <summary>
		/// Uses a buffer to read each line from file.
		/// </summary>
		List<string> fileReader();

		/// <summary>
		/// Uses a buffer to write a new line on file.
		/// </summary>
		bool writeInFile(string objectToString);

		/// <summary>
		/// Search a String target on the first data in each line of the file.
		/// </summary>
		string searchInFile(string target);

		/// <summary>
		/// It deletes the line that contain as the first data the target setted as parameter.
		/// </summary>
		bool deleteLine(string target);

		/// <summary>
		/// It cleans the file.
		/// </summary>
		bool emptyFile();

		/// <summary>
		/// Calls fileReader() method and from its output it takes all the IDs.
		/// </summary>
		List<string> getAllId();

	}
}
