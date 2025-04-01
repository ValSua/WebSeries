namespace Transversal.Helpers
{
    /// <summary>
    ///  Class RoutesPath
    /// </summary>
    public class RoutesPath
    {
        /// <summary>
        /// The controller
        /// </summary>
        public const string Controller = "Controller";
        /// <summary>
        /// The action
        /// </summary>
        public const string Action = "Action";
        /// <summary>
        /// 
        /// </summary>
        public static class Actores
        {
            /// <summary>
            /// The get actores
            /// </summary>
            public const string GetActores = "api/actores/getActores";
            /// <summary>
            /// The get actor by identifier
            /// </summary>
            public const string GetActorById = "api/actores/getActorById/{id:long}";
            /// <summary>
            /// The create actor
            /// </summary>
            public const string CreateActor = "api/actores/createActor";
            /// <summary>
            /// The update actor
            /// </summary>
            public const string UpdateActor = "api/actores/updateActor/{id:long}";
            /// <summary>
            /// The delete actor
            /// </summary>
            public const string DeleteActor = "api/actores/deleteActor/{id:long}";
        }

        public static class Directores
        {
            /// <summary>
            /// The get directores
            /// </summary>
            public const string GetDirectores = "api/directores/getDirectores";
            /// <summary>
            /// The get director by identifier
            /// </summary>
            public const string GetDirectorById = "api/directores/getDirectorById/{id:long}";
            /// <summary>
            /// The create director
            /// </summary>
            public const string CreateDirector = "api/directores/createDirector";
            /// <summary>
            /// The update director
            /// </summary>
            public const string UpdateDirector = "api/directores/updateDirector/{id:long}";
            /// <summary>
            /// The delete director
            /// </summary>
            public const string DeleteDirector = "api/directores/deleteDirector/{id:long}";
        }

        public static class Generos
        {
            /// <summary>
            /// The get generos
            /// </summary>
            public const string GetGeneros = "api/generos/getGeneros";
            /// <summary>
            /// The get genero by identifier
            /// </summary>
            public const string GetGeneroById = "api/generos/getGeneroById/{id:long}";
            /// <summary>
            /// The create genero
            /// </summary>
            public const string CreateGenero = "api/generos/createGenero";
            /// <summary>
            /// The update genero
            /// </summary>
            public const string UpdateGenero = "api/generos/updateGenero/{id:long}";
            /// <summary>
            /// The delete genero
            /// </summary>
            public const string DeleteGenero = "api/generos/deleteGenero/{id:long}";
        }

        public static class Paises
        {
            /// <summary>
            /// The get paises
            /// </summary>
            public const string GetPaises = "api/paises/getPaises";
            /// <summary>
            /// The get pais by identifier
            /// </summary>
            public const string GetPaisById = "api/paises/getPaisById";
            /// <summary>
            /// The create pais
            /// </summary>
            public const string CreatePais = "api/paises/createPais";
            /// <summary>
            /// The update pais
            /// </summary>
            public const string UpdatePais = "api/paises/updatePais";
            /// <summary>
            /// The delete pais
            /// </summary>
            public const string DeletePais = "api/paises/deletePais";
        }

        public static class Peliculas
        {
            /// <summary>
            /// The get peliculas
            /// </summary>
            public const string GetPeliculas = "api/peliculas/getPeliculas";
            /// <summary>
            /// The get pelicula by identifier
            /// </summary>
            public const string GetPeliculaById = "api/peliculas/getPeliculaById/{id:long}";
            /// <summary>
            /// The create pelicula
            /// </summary>
            public const string CreatePelicula = "api/peliculas/createPelicula";
            /// <summary>
            /// The update pelicula
            /// </summary>
            public const string UpdatePelicula = "api/peliculas/updatePelicula/{id:long}";
            /// <summary>
            /// The delete pelicula
            /// </summary>
            public const string DeletePelicula = "api/peliculas/deletePelicula/{id:long}";
        }
    }
}
