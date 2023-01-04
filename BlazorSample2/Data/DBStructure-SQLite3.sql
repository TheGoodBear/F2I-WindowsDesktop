-- SQLite3 DB structure script
-- To be executed with connection.executescript() (Python) or connection.ExecuteAsync() (C#)

CREATE TABLE IF NOT EXISTS "Animal"(
    "ID" INTEGER PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT,
    "ImageLink" TEXT,
    "IDCountry" INTEGER
);
