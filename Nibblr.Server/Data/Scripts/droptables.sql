DELETE FROM Recipes;
DELETE FROM Ingredients;
DELETE FROM Instructions;
DELETE FROM Tags;

DELETE FROM sqlite_sequence WHERE name='Recipes';
DELETE FROM sqlite_sequence WHERE name='Ingredients';
DELETE FROM sqlite_sequence WHERE name='Instructions';
DELETE FROM sqlite_sequence WHERE name='Tags';
