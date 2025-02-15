-- Inserting sample recipes into Recipe table
INSERT INTO "Recipe" (Name, Description, URL) VALUES 
('Spaghetti Bolognese', 'A classic Italian pasta dish with rich meat sauce.', 'https://www.example.com/spaghetti-bolognese'),
('Chicken Salad', 'A healthy salad with grilled chicken, lettuce, and vegetables.', 'https://www.example.com/chicken-salad'),
('Pancakes', 'Fluffy pancakes served with syrup and butter.', 'https://www.example.com/pancakes'),
('Grilled Cheese Sandwich', 'A simple and delicious grilled cheese sandwich.', 'https://www.example.com/grilled-cheese'),
('Vegetable Stir Fry', 'A mix of stir-fried vegetables with soy sauce and spices.', 'https://www.example.com/vegetable-stir-fry');

-- Inserting ingredients for Spaghetti Bolognese (Recipe ID = 1)
INSERT INTO "Ingredients" (Name, Quantity, Weight, WeightUnit, Description, RecipeId) VALUES
('Spaghetti', 200, 200, 'grams', 'Pasta for the main dish', 1),
('Ground Beef', 300, 300, 'grams', 'Lean ground beef', 1),
('Tomato Sauce', 150, 150, 'ml', 'Sauce made from tomatoes', 1),
('Garlic', 2, NULL, NULL, 'Minced garlic cloves', 1),
('Olive Oil', 1, 10, 'ml', 'For cooking the garlic and beef', 1);

-- Inserting instructions for Spaghetti Bolognese (Recipe ID = 1)
INSERT INTO "Instructions" (Step, Body, RecipeId) VALUES
(1, 'Cook the spaghetti according to package instructions.', 1),
(2, 'Heat olive oil in a pan and cook garlic until fragrant.', 1),
(3, 'Add ground beef to the pan and cook until browned.', 1),
(4, 'Add tomato sauce to the pan and simmer for 10 minutes.', 1),
(5, 'Serve the sauce over cooked spaghetti.', 1);

-- Inserting macros for Spaghetti Bolognese (Recipe ID = 1)
INSERT INTO "Macros" (Fat, Carbs, Protein, RecipeId) VALUES
(15, 50, 30, 1);

-- Inserting ingredients for Chicken Salad (Recipe ID = 2)
INSERT INTO "Ingredients" (Name, Quantity, Weight, WeightUnit, Description, RecipeId) VALUES
('Chicken Breast', 200, 200, 'grams', 'Grilled chicken breast', 2),
('Lettuce', 100, 100, 'grams', 'Fresh leafy greens', 2),
('Cucumber', 50, 50, 'grams', 'Sliced cucumber', 2),
('Tomato', 50, 50, 'grams', 'Sliced tomato', 2),
('Olive Oil', 1, 10, 'ml', 'For the dressing', 2);

-- Inserting instructions for Chicken Salad (Recipe ID = 2)
INSERT INTO "Instructions" (Step, Body, RecipeId) VALUES
(1, 'Grill the chicken breast and slice it into thin pieces.', 2),
(2, 'Wash and chop the lettuce, cucumber, and tomato.', 2),
(3, 'Toss the ingredients together in a bowl and drizzle with olive oil.', 2),
(4, 'Serve immediately.', 2);

-- Inserting macros for Chicken Salad (Recipe ID = 2)
INSERT INTO "Macros" (Fat, Carbs, Protein, RecipeId) VALUES
(10, 8, 40, 2);

-- Inserting ingredients for Pancakes (Recipe ID = 3)
INSERT INTO "Ingredients" (Name, Quantity, Weight, WeightUnit, Description, RecipeId) VALUES
('Flour', 200, 200, 'grams', 'All-purpose flour', 3),
('Egg', 2, NULL, NULL, 'Large eggs', 3),
('Milk', 150, 150, 'ml', 'Whole milk', 3),
('Baking Powder', 1, 5, 'grams', 'For fluffiness', 3),
('Butter', 30, 30, 'grams', 'Melted butter for the batter', 3);

-- Inserting instructions for Pancakes (Recipe ID = 3)
INSERT INTO "Instructions" (Step, Body, RecipeId) VALUES
(1, 'Mix the flour, eggs, milk, and baking powder into a smooth batter.', 3),
(2, 'Heat a non-stick pan and cook the pancakes on both sides until golden brown.', 3),
(3, 'Serve with syrup and butter.', 3);

-- Inserting macros for Pancakes (Recipe ID = 3)
INSERT INTO "Macros" (Fat, Carbs, Protein, RecipeId) VALUES
(15, 60, 8, 3);

-- Inserting ingredients for Grilled Cheese Sandwich (Recipe ID = 4)
INSERT INTO "Ingredients" (Name, Quantity, Weight, WeightUnit, Description, RecipeId) VALUES
('Bread', 2, 50, 'grams', 'Two slices of bread', 4),
('Cheese', 2, 50, 'grams', 'Cheddar cheese slices', 4),
('Butter', 20, 20, 'grams', 'For spreading on the bread', 4);

-- Inserting instructions for Grilled Cheese Sandwich (Recipe ID = 4)
INSERT INTO "Instructions" (Step, Body, RecipeId) VALUES
(1, 'Butter one side of each slice of bread.', 4),
(2, 'Place cheese between the slices of bread with the buttered side facing out.', 4),
(3, 'Grill the sandwich in a pan until golden brown and the cheese is melted.', 4),
(4, 'Serve hot.', 4);

-- Inserting macros for Grilled Cheese Sandwich (Recipe ID = 4)
INSERT INTO "Macros" (Fat, Carbs, Protein, RecipeId) VALUES
(20, 30, 15, 4);

-- Inserting ingredients for Vegetable Stir Fry (Recipe ID = 5)
INSERT INTO "Ingredients" (Name, Quantity, Weight, WeightUnit, Description, RecipeId) VALUES
('Broccoli', 100, 100, 'grams', 'Fresh broccoli florets', 5),
('Carrot', 50, 50, 'grams', 'Sliced carrots', 5),
('Bell Pepper', 50, 50, 'grams', 'Chopped bell peppers', 5),
('Soy Sauce', 20, 20, 'ml', 'For flavor', 5),
('Olive Oil', 1, 10, 'ml', 'For stir-frying', 5);

-- Inserting instructions for Vegetable Stir Fry (Recipe ID = 5)
INSERT INTO "Instructions" (Step, Body, RecipeId) VALUES
(1, 'Heat olive oil in a pan and sauté the vegetables for 5 minutes.', 5),
(2, 'Add soy sauce and stir-fry for another 2 minutes.', 5),
(3, 'Serve immediately.', 5);

-- Inserting macros for Vegetable Stir Fry (Recipe ID = 5)
INSERT INTO "Macros" (Fat, Carbs, Protein, RecipeId) VALUES
(10, 15, 3, 5);
