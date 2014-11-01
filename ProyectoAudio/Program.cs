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
			var filenameOrigin = "BPM"; // get the name of the folder
			var originPath = Path.Combine (documentsPath, filenameOrigin); // relative path
			string title = "",artist="",album=""; //properties init
			uint year = DateTime.Now.Year;
			var comments = "";
			string filename = "";


			string[] files = Directory.GetFiles(originPath, "*.mp3", SearchOption.AllDirectories);

			if (files.Length) {
				Console.WriteLine ("EL DIRECTORIO NO EXISTE");
			}


			foreach (var fileName in files){
				using (TagLib.File file = TagLib.File.Create (fileName)) {



					filename = file.Name.Substring (27);

					filename = file.Name.Substring (23, filename.Length - 4);

					filename.Replace ("www.livingelectro.com", "");

					file.RemoveTags (TagTypes.AllTags);

					file.Save ();

					int pos = filename.IndexOf ("-");
					artist = filename.Substring (0, pos - 1);
					title = filename.Substring (pos + 2);
				}

			}


			foreach (var fileName in files) {
				using (TagLib.File file2 = TagLib.File.Create (originPath)) {

					file2.Tag.Title = title;
					file2.Tag.Album = title;
					file2.Tag.Year = year;
					file2.Tag.Comment = comments;
					file2.Tag.Performers = null;
					file2.Tag.Performers = new []{ artist };

					file2.Save ();

					System.Console.WriteLine ("Title:  " + file.Tag.Title);
					System.Console.WriteLine ("Album:  " + file.Tag.Album);
					System.Console.WriteLine ("Year: " + file.Tag.Year);
					System.Console.WriteLine ("Artist: " + file.Tag.FirstPerformer);

				}
			}

				
	}


		
  }
}
