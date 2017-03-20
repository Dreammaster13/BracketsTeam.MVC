using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Entities;

namespace BracketsTeam.Logic
{
    /// <summary>
    ///
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        ///
        /// </summary>
        public static class LengthDefinition
        {
            /// <summary>
            ///
            /// </summary>
            public static class Game
            {
                //public static int Name
                //{ get
                //{
                //return Entities.Extensions.GetMaxLength(new Entities.DBContext_BracketsTeam(), "Game", "Name").GetValueOrDefault(0);
                //}
                //}
                public static int Name = 128;
            }

            /// <summary>
            ///
            /// </summary>
            public static class Match
            {

            }

            /// <summary>
            ///
            /// </summary>
            public static class Match_Player
            {

            }

            /// <summary>
            ///
            /// </summary>
            public static class Player
            {
                public static int DV = 1;
                public static int Name = 32;
                public static int LastName = 32;
                public static int UserName = 32;
                public static int NickName = 32;
                public static int AltNickName = 32;
            }

            /// <summary>
            ///
            /// </summary>
            public static class Prize
            {
                public static int Name = 256;
                public static int ExchangeRate = 3;
            }

            /// <summary>
            ///
            /// </summary>
            public static class Team
            {
                public static int Name = 64;
                public static int NameShort = 4;
            }

            /// <summary>
            ///
            /// </summary>
            public static class Team_Player
            {

            }

            /// <summary>
            ///
            /// </summary>
            public static class Team_Tournament
            {

            }

            /// <summary>
            ///
            /// </summary>
            public static class Tournament
            {
                public static int Name = 256;
            }

            /// <summary>
            ///
            /// </summary>
            public static class Tournament_Prize
            {

            }
        }

        public static class Messages
        {
            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public static string AddMessageToHTML(string message)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<li>");
                sb.Append(message);
                sb.Append("</li>");

                return sb.ToString();
            }

            public static class Team
            {
                public static string AddTeam_Success = AddMessageToHTML("<strong>Equipo</strong> se agregó correctamente.");

                public static string AddTeam_Error_General = AddMessageToHTML("Ocurrió un error al agregar el <strong>Equipo</strong>.");
                public static string AddTeam_Error_EmptyName = AddMessageToHTML("Debe ingresar un <strong>Nombre</strong> al <strong>Equipo</strong>.");
                public static string AddTeam_Error_EmptyShortName = AddMessageToHTML("Debe ingresar un <strong>Nombre Corto</strong> al <strong>Equipo</strong>.");
                public static string AddTeam_Error_EmptyGame = AddMessageToHTML("Debe seleccionar un <strong>Juego</strong> para agregar al <strong>Equipo</strong>.");

                public static string AddTeam_Warning_Inactive = AddMessageToHTML("El <strong>Equipo</strong> no está <strong>activo</strong>.");
            }
        }
    }
}
