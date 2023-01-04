-- SQLite3 initial data script
-- To be executed with connection.executescript() (Python) or connection.ExecuteAsync() (C#)

INSERT INTO "Animal" ("ID","Name","Description","ImageLink","IDCountry") VALUES
	 (1,"Lapin","Doux avec des grandes oreilles",NULL,NULL),
	 (2,"Chat","Doux avec des petites oreilles, fait miaou",NULL,NULL),
	 (3,"Chien","Fait wafwaf",NULL,NULL),
	 (4,"Cochon","Rose et fait gruic",NULL,NULL),
	 (5,"Mésange","Vole",NULL,NULL),
	 (6,"Serpent","Rampe",NULL,NULL),
	 (7,"Chèvre","Mange tout même les ronces",NULL,NULL);
