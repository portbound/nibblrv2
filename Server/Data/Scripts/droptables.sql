-- Drop all tables
DELETE FROM Recipes;
DELETE FROM sqlite_sequence WHERE name='Recipes';

DELETE FROM Ingredients;
DELETE FROM sqlite_sequence WHERE name='Ingredients';

DELETE FROM Instructions;
DELETE FROM sqlite_sequence WHERE name='Instructions';

DELETE FROM Macros;
DELETE FROM sqlite_sequence WHERE name='Macros';

DELETE FROM Categories;
DELETE FROM sqlite_sequence WHERE name='Categories';
