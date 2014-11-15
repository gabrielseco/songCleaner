using System;
using System.IO;
using TagLib;

namespace ProyectoAudio
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop); // get the folderPath
			var folder = "BPM"; // get the name of the folder
			var originPath = Path.Combine (documentsPath, folder); // relative path
			string title = "",artist = "",comments = "",filename = ""; //properties init
			int pos = -1; 

			string[] files = Directory.GetFiles(originPath, "*.mp3", SearchOption.AllDirectories); // we save all the names in array

			if (files.Length == 0) {
				Console.WriteLine ("EL DIRECTORIO {0} NO EXISTE",folder);
			}


			foreach (var fileName in files){ //for every instance we clean all the tags and we clean the filename to save in the next using
				using (TagLib.File file = TagLib.File.Create (fileName)) {

					Console.WriteLine (fileName);

					filename = file.Name;

					filename = filename.Substring (fileName.LastIndexOf("/")+1);


					//filename = filename.Substring(0,filename.IndexOf ("www.livingelectro.com"));


					Console.WriteLine (filename);

					pos = filename.IndexOf ("-");

					Console.WriteLine ("La posicion es: " + pos);


					artist = filename.Substring (0, pos - 1);
					title = filename.Substring (pos + 2);

					file.RemoveTags (TagTypes.AllTags);
					file.Save ();

				}

				using (TagLib.File file2 = TagLib.File.Create (fileName)) {

					title = title.Substring (0,title.LastIndexOf("."));

					file2.Tag.Title = title;
					file2.Tag.Album = title;
					file2.Tag.Year = (uint)DateTime.Now.Year;
					file2.Tag.Comment = comments;
					file2.Tag.Performers = null;
					file2.Tag.Performers = new []{ artist };

					file2.Save ();



				}

			}




				
	}


		
  }
}
