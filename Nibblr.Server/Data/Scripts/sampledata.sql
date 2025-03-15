-- Insert recipe data into your existing schema
INSERT INTO "Recipes"
("ID", "Name", "Description", "URL", "Bookmarked", "Servings", "Calories", "Fat", "Carbs", "Protein")
VALUES
-- Recipe 1: Classic Spaghetti Bolognese
(1,
 'Classic Spaghetti Bolognese',
 'A rich and hearty Italian pasta dish with a meaty tomato sauce.',
 'https://www.example.com/spaghetti-bolognese',
 0,
 4,
 520,
 18.5,
 65.2,
 28.7),

-- Recipe 2: Avocado Toast with Poached Egg
(2,
 'Avocado Toast with Poached Egg',
 'A nutritious breakfast that combines creamy avocado with perfectly poached eggs.',
 'https://www.example.com/avocado-toast',
 1,
 1,
 320,
 21.3,
 24.6,
 12.8),

-- Recipe 3: Chicken Tikka Masala
(3,
 'Chicken Tikka Masala',
 'A flavorful Indian curry dish with tender chicken in a creamy tomato sauce.',
 'https://www.example.com/chicken-tikka-masala',
 0,
 2,
 490,
 22.5,
 30.8,
 41.3),

-- Recipe 4: Blueberry Pancakes
(4,
 'Blueberry Pancakes',
 'Fluffy pancakes studded with juicy blueberries, perfect for a weekend breakfast.',
 'https://www.example.com/blueberry-pancakes',
 1,
 3,
 380,
 12.4,
 59.3,
 9.2),

-- Recipe 5: Roasted Vegetable Quinoa Bowl
(5,
 'Roasted Vegetable Quinoa Bowl',
 'A nutritious and colorful grain bowl packed with roasted vegetables and protein-rich quinoa.',
 'https://www.example.com/quinoa-bowl',
 0,
 1,
 420,
 15.2,
 58.6,
 14.8);

-- Recipe 1: Classic Spaghetti Bolognese - Ingredients
INSERT INTO "Ingredients" ("RecipeID", "Name", "Quantity", "Unit", "Notes")
VALUES
    (1, 'Spaghetti', 400, 'g', ''),
    (1, 'Ground Beef', 1, 'lb', ''),
    (1, 'Onion', 1, 'whole', ''),
    (1, 'Garlic', 2, 'cloves', 'minced'),
    (1, 'Carrot', 1, 'whole', 'Finely diced'),
    (1, 'Celery', 1, 'stalk', 'Finely diced'),
    (1, 'Tomato Paste', 2, 'tbsp', ''),
    (1, 'Crushed Tomatoes', 1, 'can', ''),
    (1, 'Red Wine', 0.5, 'cup', ''),
    (1, 'Beef Stock', 1, 'cup', ''),
    (1, 'Parmesan Cheese', 50, 'g', 'Grated, for serving');

-- Recipe 1: Classic Spaghetti Bolognese - Instructions
INSERT INTO "Instructions" ("RecipeID", "Step", "Body")
VALUES
    (1, 1, 'Heat oil in a large pot over medium heat. Add onions, carrots, and celery, and cook until softened, about 5 minutes.'),
    (1, 2, 'Add garlic and cook for another minute until fragrant.'),
    (1, 3, 'Increase heat to medium-high and add ground beef. Cook, breaking it apart with a spoon, until browned.'),
    (1, 4, 'Add tomato paste and stir for 1-2 minutes.'),
    (1, 5, 'Pour in red wine and simmer until reduced by half, about 2-3 minutes.'),
    (1, 6, 'Add crushed tomatoes and beef stock. Season with salt and pepper.'),
    (1, 7, 'Reduce heat to low and simmer, partially covered, for at least 1 hour.'),
    (1, 8, 'Meanwhile, cook spaghetti according to package instructions.'),
    (1, 9, 'Serve sauce over spaghetti and top with grated Parmesan cheese.');

-- Recipe 2: Avocado Toast with Poached Egg - Ingredients
INSERT INTO "Ingredients" ("RecipeID", "Name", "Quantity", "Unit", "Notes")
VALUES
    (2, 'Sourdough Bread', 2, 'slices', ''),
    (2, 'Avocado', 1, 'whole', 'Ripe'),
    (2, 'Eggs', 2, 'whole', ''),
    (2, 'Lemon', 0.5, 'whole', 'Juice only'),
    (2, 'Red Pepper Flakes', 0.25, 'tsp', ''),
    (2, 'Salt', 0.5, 'tsp', ''),
    (2, 'Black Pepper', 0.25, 'tsp', 'freshly ground'),
    (2, 'Fresh Herbs', 1, 'tbsp', 'Such as cilantro or chives, chopped');

-- Recipe 2: Avocado Toast with Poached Egg - Instructions
INSERT INTO "Instructions" ("RecipeID", "Step", "Body")
VALUES
    (2, 1, 'Toast the bread slices until golden and crisp.'),
    (2, 2, 'Cut the avocado in half, remove the pit, and scoop the flesh into a bowl.'),
    (2, 3, 'Add lemon juice, salt, and pepper to the avocado and mash with a fork, leaving some chunks for texture.'),
    (2, 4, 'Bring a pot of water to a gentle simmer and add a splash of vinegar.'),
    (2, 5, 'Crack each egg into a small cup, then gently slide into the simmering water.'),
    (2, 6, 'Poach eggs for 3-4 minutes for runny yolks.'),
    (2, 7, 'Spread the mashed avocado on the toast slices.'),
    (2, 8, 'Using a slotted spoon, remove the poached eggs and place on top of the avocado.'),
    (2, 9, 'Sprinkle with red pepper flakes and fresh herbs. Season with additional salt and pepper if desired.');

-- Recipe 3: Chicken Tikka Masala - Ingredients
INSERT INTO "Ingredients" ("RecipeID", "Name", "Quantity", "Unit", "Notes")
VALUES
    (3, 'Chicken Breasts', 2, 'whole', 'Cut into chunks'),
    (3, 'Plain Yogurt', 0.5, 'cup', ''),
    (3, 'Lemon Juice', 2, 'tbsp', ''),
    (3, 'Garam Masala', 2, 'tbsp', 'divided'),
    (3, 'Ground Turmeric', 1, 'tsp', ''),
    (3, 'Ground Cumin', 1, 'tsp', ''),
    (3, 'Ground Coriander', 1, 'tsp', ''),
    (3, 'Paprika', 1, 'tsp', ''),
    (3, 'Onion', 1, 'large', 'finely chopped'),
    (3, 'Garlic', 4, 'cloves', 'minced'),
    (3, 'Ginger', 1, 'inch', 'grated'),
    (3, 'Tomato Sauce', 1, 'can', ''),
    (3, 'Heavy Cream', 1, 'cup', ''),
    (3, 'Fresh Cilantro', 0.25, 'cup', 'chopped');

-- Recipe 3: Chicken Tikka Masala - Instructions
INSERT INTO "Instructions" ("RecipeID", "Step", "Body")
VALUES
    (3, 1, 'In a bowl, combine yogurt, lemon juice, 1 tablespoon garam masala, turmeric, cumin, coriander, and paprika.'),
    (3, 2, 'Add chicken pieces and coat well. Marinate for at least 30 minutes, preferably 2-4 hours.'),
    (3, 3, 'Preheat oven to 425°F (220°C). Place marinated chicken on a baking sheet and bake for 15 minutes.'),
    (3, 4, 'Meanwhile, heat oil in a large skillet over medium heat. Add onions and cook until softened, about 5 minutes.'),
    (3, 5, 'Add garlic and ginger, cook for another minute until fragrant.'),
    (3, 6, 'Add remaining tablespoon of garam masala and stir for 30 seconds.'),
    (3, 7, 'Pour in the tomato sauce and bring to a simmer. Cook for 5 minutes.'),
    (3, 8, 'Stir in heavy cream and simmer until sauce thickens slightly, about 5 minutes.'),
    (3, 9, 'Add the baked chicken pieces to the sauce and simmer for an additional 5 minutes.'),
    (3, 10, 'Garnish with chopped cilantro and serve with rice or naan bread.');

-- Recipe 4: Blueberry Pancakes - Ingredients
INSERT INTO "Ingredients" ("RecipeID", "Name", "Quantity", "Unit", "Notes")
VALUES
    (4, 'All-Purpose Flour', 1.5, 'cups', ''),
    (4, 'Sugar', 3, 'tbsp', ''),
    (4, 'Baking Powder', 1.5, 'tsp', ''),
    (4, 'Salt', 0.5, 'tsp', ''),
    (4, 'Milk', 1.25, 'cups', ''),
    (4, 'Eggs', 2, 'whole', ''),
    (4, 'Unsalted Butter', 3, 'tbsp', 'melted'),
    (4, 'Vanilla Extract', 1, 'tsp', ''),
    (4, 'Fresh Blueberries', 1, 'cup', ''),
    (4, 'Maple Syrup', 0.5, 'cup', 'for serving');

-- Recipe 4: Blueberry Pancakes - Instructions
INSERT INTO "Instructions" ("RecipeID", "Step", "Body")
VALUES
    (4, 1, 'In a large bowl, whisk together the flour, sugar, baking powder, and salt.'),
    (4, 2, 'In another bowl, whisk together the milk, eggs, melted butter, and vanilla extract.'),
    (4, 3, 'Pour the wet ingredients into the dry ingredients and stir just until combined. Some lumps are okay.'),
    (4, 4, 'Gently fold in the blueberries.'),
    (4, 5, 'Heat a griddle or non-stick pan over medium heat. Lightly grease with butter or cooking spray.'),
    (4, 6, 'Pour about 1/4 cup of batter for each pancake onto the griddle.'),
    (4, 7, 'Cook until bubbles form on the surface and the edges look set, about 2-3 minutes.'),
    (4, 8, 'Flip and cook the other side until golden brown, about 1-2 minutes more.'),
    (4, 9, 'Serve warm with maple syrup.');

-- Recipe 5: Roasted Vegetable Quinoa Bowl - Ingredients
INSERT INTO "Ingredients" ("RecipeID", "Name", "Quantity", "Unit", "Notes")
VALUES
    (5, 'Quinoa', 1, 'cup', 'uncooked'),
    (5, 'Vegetable Broth', 2, 'cups', ''),
    (5, 'Sweet Potato', 1, 'medium', 'cubed'),
    (5, 'Bell Peppers', 2, 'whole', 'Mixed colors, sliced'),
    (5, 'Red Onion', 1, 'medium', 'sliced'),
    (5, 'Zucchini', 1, 'medium', 'sliced'),
    (5, 'Chickpeas', 1, 'can', 'drained and rinsed'),
    (5, 'Olive Oil', 3, 'tbsp', ''),
    (5, 'Lemon', 1, 'whole', 'Juiced'),
    (5, 'Cumin', 2, 'tsp', ''),
    (5, 'Paprika', 1, 'tsp', ''),
    (5, 'Garlic Powder', 1, 'tsp', ''),
    (5, 'Avocado', 1, 'whole', 'Sliced'),
    (5, 'Feta Cheese', 0.5, 'cup', 'crumbled'),
    (5, 'Fresh Parsley', 0.25, 'cup', 'chopped');

-- Recipe 5: Roasted Vegetable Quinoa Bowl - Instructions
INSERT INTO "Instructions" ("RecipeID", "Step", "Body")
VALUES
    (5, 1, 'Preheat oven to 425°F (220°C).'),
    (5, 2, 'Rinse quinoa thoroughly. In a saucepan, combine quinoa and vegetable broth. Bring to a boil, reduce heat, cover, and simmer for 15 minutes. Remove from heat and let stand, covered, for 5 minutes.'),
    (5, 3, 'On a large baking sheet, toss sweet potato, bell peppers, red onion, zucchini, and chickpeas with olive oil, cumin, paprika, garlic powder, salt, and pepper.'),
    (5, 4, 'Spread vegetables in a single layer and roast for 25-30 minutes, stirring halfway through, until tender and slightly caramelized.'),
    (5, 5, 'Fluff the quinoa with a fork and stir in half of the lemon juice.'),
    (5, 6, 'Divide quinoa among four bowls and top with roasted vegetables and chickpeas.'),
    (5, 7, 'Add sliced avocado and crumbled feta cheese to each bowl.'),
    (5, 8, 'Drizzle with remaining lemon juice and olive oil if desired.'),
    (5, 9, 'Garnish with fresh parsley and serve.');

-- Add tags
INSERT INTO "Tags" ("ID", "Name")
VALUES
    (1, 'Vegetarian'),
    (2, 'High Protein'),
    (3, 'Low Carb'),
    (4, 'Dessert'),
    (5, 'Breakfast'),
    (6, 'Kid Friendly'),
    (7, 'Side Dish'),
    (8, 'Gluten Free'),
    (9, 'Dairy Free'),
    (10, 'Nut Free'),
    (11, 'Healthy'),
    (12, 'Pescatarian'),
    (13, 'Paleo'),
    (14, 'Low Fat'),
    (15, 'Quick & Easy'),
    (16, 'Sugar Free'),
    (17, 'Seasonal'),
    (18, 'Hispanic'),
    (19, 'Asian'),
    (20, 'European'),
    (21, 'Indian'),
    (22, 'American'),
    (23, 'African');