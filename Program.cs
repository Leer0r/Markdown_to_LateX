﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace md_to_latex {
    class Program {
        static void Main (string[] args) {
            if (args.Length == 0) {
                throw new ArgumentException ("Requière au moins un argument");
            }
            addFunction addFunction = new addFunction ();

            if (!addFunction.verif_ext_file (args[0], ".md")) {
                throw new ArgumentException ("Le fichier passé en paramètre doit etre un fichier markdown");
            }

            try {
                StreamReader file = new StreamReader (args[0]);
                converter converter = new converter (file);
            } catch (FileNotFoundException) {
                throw new FileNotFoundException ("Le fichier n'existe pas");
            } catch (Exception e) {
                Console.WriteLine ("Erreur inconnue : " + e.Message);
            }
        }
    }

    class addFunction {
        public bool verif_ext_file (string file_name, string ext) {
            string ext_file = Path.GetExtension (file_name);
            if (ext == ext_file) {
                return true;
            }
            return false;
        }
    }

    public class converter {
        public converter (StreamReader file) {
            //On sais ici que le fichier existe et qu'il est dans le bon format

            bool is_template;
            string[] template = get_template (file, out is_template);
            print_template (template);
            if (is_template) { }
        }

        static string[] get_template (StreamReader file, out bool is_template) {
            string _line = file.ReadLine ();

            Regex rx = new Regex (@"^<!---template$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches (_line);

            string[] template = new string[nb_arg_template.nb];

            if (matches.Count != 0) {
                _line = file.ReadLine ();
                int count = 0;
                while (!match_regex (@"-->$", _line)) {
                    try {
                        template[count] = _line;
                        _line = file.ReadLine ();
                        count++;
                    } catch (IndexOutOfRangeException) {
                        error_exeption.warning (String.Format ("Le template fournis a plus de paramètre que le maximum prévu par le programme, vérifier votre template ou mettez a jours cette application. Seul les {0} premiers paramètres seronts pris en compte", template.Length));
                        is_template = false;
                        break;
                    }
                }
                is_template = true;

            } else {
                is_template = false;
                error_exeption.info ("Aucun template n'a été trouvé");
            }
            return template;
        }

        static bool compile_template (string[] template) {
            for (int i = 0; i < template.Length; i++) {

            }
            return true;
        }

        static bool match_regex (string patern, string str) {
            Regex match = new Regex (patern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = match.Matches (str);
            if (matches.Count == 0) {
                return false;
            }
            return true;
        }

        static void print_template (string[] template) {
            for (int i = 0; i < template.Length; i++) {
                if (template[i] == null) {
                    break;
                }
                Console.WriteLine (template[i]);
            }
        }
    }

    class error_exeption {
        public static void warning (string message) {
            string display = "Attention : " + message;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine (display);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void info (string message) {
            string display = "Info : " + message;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine (display);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class nb_arg_template {
        private const int nb_args = 4;
        static public int nb {
            get => nb_args;
            private set { }
        }
    }
}