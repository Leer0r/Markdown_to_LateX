using System;
using System.IO;
using System.Text.RegularExpressions;

/**
  * Main program
  */
namespace md_to_latex
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // need at least one argument
            if(args.Length == 0) {
                throw new ArgumentException("1 argument expected (markdown file path).");
            }

            addFunction addFunction = new addFunction();

            if(!addFunction.verif_ext_file(args[0],".md")) {
                throw new ArgumentException("You have to pass markdown file's path.");
            }

            try {
                StreamReader file = new StreamReader(args[0]);
                converter converter = new converter(file);
            }
            
            catch(FileNotFoundException) {
                throw new FileNotFoundException("File not found.");
            }

            catch(Exception e) {
                Console.WriteLine("Unknown error : " + e.Message);
            }
        }
    }


    class addFunction {
        public bool verif_ext_file(string file_name, string ext) {
            string ext_file = Path.GetExtension(file_name);

            if(ext == ext_file) {
                return true;
            }

            return false;
        }
    }


    public class converter {
        public converter(StreamReader file) {
            // Here we know that the file exists and has good format

            bool is_template;
            string[] template = get_template(file, out is_template);

            if(is_template) {
                for(int i = 0; i < template.Length; i++)
                {
                    if(template[i] == null) {
                        break;
                    }

                    Console.WriteLine(template[i]);
                }
            }
        }

        static string[] get_template(StreamReader file, out bool is_template) {
            string _line = file.ReadLine();

            Regex rx = new Regex(@"^<!---template$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(_line);

            string[] template = new string[10];

            if(matches.Count != 0) {
                _line = file.ReadLine();
                is_template = true;
                int count = 0;

                while(!match_regex(@"-->$",_line)) {
                    try{
                        template[count] = _line;
                        _line = file.ReadLine();
                        count++;
                    }

                    catch(IndexOutOfRangeException) {
                        error_exeption.warning(String.Format("The template received more parameters than the program can handle, please check your template or update this application. The only {0} first parameters will be taken into account.", template.Length));
                        break;
                    }
                }
            }

            else {
                is_template = false;
            }

            return template;
            
        }

        static bool match_regex(string patern, string str) {
            Regex match = new Regex(patern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = match.Matches(str);
            
            if(matches.Count == 0) {
                return false;
            }

            return true;
        }
    }


    class error_exeption {
        public static void warning(string message) {
            string display = "Warning : " + message;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(display);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
