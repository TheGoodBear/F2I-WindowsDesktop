NOTE sur SQLite 3
-----------------

https://stackoverflow.com/questions/67966259/how-to-use-sqlite-in-blazor-webassembly

Sur Androïd :
SQLite provoque une erreur sur l'émulateur
voir à utiliser plutôt le package Microsoft.EntityFrameworkCore.Sqlite

En Web assembly :
SQLite n'est pas adapté (limite de 5Mo de storage sur le client en LocalStorage)
S'orienter plutôt vers IndexedDB et synchroniser avec le serveur
