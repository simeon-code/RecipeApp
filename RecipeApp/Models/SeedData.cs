using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace RecipeApp.Models
{
    public static class SeedData
    {
        private static byte[] ImgToByteArray(string filePath)
        {
            byte[] byteArray;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byteArray = new byte[fileStream.Length];
                fileStream.Read(byteArray, 0, (int)fileStream.Length);
            }

            return byteArray;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Recipes == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any recipe.
                if (context.Recipes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Caprese Skewers",
                        Category = "Appetizer",
                        Description = "These Caprese skewers are a perfect appetizer for any occasion. They feature fresh cherry tomatoes, mozzarella cheese, and basil leaves, all drizzled with a balsamic glaze.\n\n" +
                            "Ingredients:\n" +
                            "- Fresh cherry tomatoes\n" +
                            "- Mozzarella cheese\n" +
                            "- Basil leaves\n" +
                            "- Balsamic glaze\n\n" +
                            "Steps:\n" +
                            "1. Skewer a cherry tomato, a piece of mozzarella cheese, and a basil leaf onto each skewer.\n" +
                            "2. Arrange the skewers on a serving platter.\n" +
                            "3. Drizzle the skewers with balsamic glaze.\n" +
                            "4. Serve and enjoy!",
                        Portions = 6,
                        PrepareTime = 15,
                        ImageData = ImgToByteArray("Models/images/caprese_skewers.jpg")
                    },
                    new Recipe
                    {
                        Name = "Spinach and Artichoke Dip",
                        Category = "Appetizer",
                        Description = "This creamy spinach and artichoke dip is a crowd-pleasing appetizer. It combines tender spinach, artichoke hearts, cream cheese, and Parmesan cheese, baked until golden and bubbly.\n\n" +
                            "Ingredients:\n" +
                            "- Spinach\n" +
                            "- Artichoke hearts\n" +
                            "- Cream cheese\n" +
                            "- Parmesan cheese\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 350°F (175°C).\n" +
                            "2. In a mixing bowl, combine chopped spinach, artichoke hearts, cream cheese, and Parmesan cheese.\n" +
                            "3. Transfer the mixture to a baking dish.\n" +
                            "4. Bake for 25-30 minutes or until golden and bubbly.\n" +
                            "5. Serve hot with tortilla chips or bread slices.",
                        Portions = 8,
                        PrepareTime = 30,
                        ImageData = ImgToByteArray("Models/images/spinach_and_artichoke_dip.jpg")
                    },
                    new Recipe
                    {
                        Name = "Bruschetta",
                        Category = "Appetizer",
                        Description = "Bruschetta is a classic Italian appetizer that consists of toasted bread topped with fresh tomatoes, garlic, basil, and olive oil. It's simple, flavorful, and perfect for any gathering.\n\n" +
                            "Ingredients:\n" +
                            "- Baguette or Italian bread\n" +
                            "- Fresh tomatoes\n" +
                            "- Garlic cloves\n" +
                            "- Fresh basil leaves\n" +
                            "- Olive oil\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 375°F (190°C).\n" +
                            "2. Slice the baguette or Italian bread into thick slices.\n" +
                            "3. Arrange the bread slices on a baking sheet and brush each slice with olive oil.\n" +
                            "4. Toast the bread slices in the oven for about 5-7 minutes or until lightly golden.\n" +
                            "5. In a bowl, combine diced tomatoes, minced garlic, chopped basil leaves, and a drizzle of olive oil.\n" +
                            "6. Top each toasted bread slice with the tomato mixture.\n" +
                            "7. Serve immediately and enjoy!",
                        Portions = 4,
                        PrepareTime = 20,
                        ImageData = ImgToByteArray("Models/images/bruschetta.jpg")
                    },
                    new Recipe
                    {
                        Name = "Chicken Parmesan",
                        Category = "Main Dish",
                        Description = "Chicken Parmesan is a delicious and comforting main dish. It features breaded chicken breasts topped with marinara sauce, melted mozzarella cheese, and Parmesan cheese, served over spaghetti.\n\n" +
                            "Ingredients:\n" +
                            "- Chicken breasts\n" +
                            "- Bread crumbs\n" +
                            "- Eggs\n" +
                            "- All-purpose flour\n" +
                            "- Marinara sauce\n" +
                            "- Mozzarella cheese\n" +
                            "- Parmesan cheese\n" +
                            "- Spaghetti\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 375°F (190°C).\n" +
                            "2. Pound the chicken breasts to an even thickness.\n" +
                            "3. In separate shallow bowls, place flour, beaten eggs, and bread crumbs.\n" +
                            "4. Dredge each chicken breast in flour, dip in beaten eggs, and coat with bread crumbs.\n" +
                            "5. Heat oil in a skillet over medium heat and cook the breaded chicken breasts until golden and cooked through.\n" +
                            "6. Spread marinara sauce over the bottom of a baking dish.\n" +
                            "7. Place the cooked chicken breasts on top of the sauce.\n" +
                            "8. Top each chicken breast with marinara sauce, mozzarella cheese, and Parmesan cheese.\n" +
                            "9. Bake in the preheated oven for about 20 minutes or until the cheese is melted and bubbly.\n" +
                            "10. Cook the spaghetti according to package instructions.\n" +
                            "11. Serve the chicken Parmesan over the cooked spaghetti.\n" +
                            "12. Enjoy!",
                        Portions = 4,
                        PrepareTime = 45,
                        ImageData = ImgToByteArray("Models/images/chicken_parmesan.jpg")
                    },
                    new Recipe
                    {
                        Name = "Beef Tacos",
                        Category = "Main Dish",
                        Description = "These beef tacos are a quick and easy main dish. Seasoned ground beef is cooked and served in warm tortillas, topped with your favorite taco fixings such as lettuce, cheese, and salsa.\n\n" +
                            "Ingredients:\n" +
                            "- Ground beef\n" +
                            "- Taco seasoning\n" +
                            "- Tortillas\n" +
                            "- Lettuce\n" +
                            "- Shredded cheese\n" +
                            "- Salsa\n" +
                            "- Optional toppings: diced tomatoes, onions, sour cream\n\n" +
                            "Steps:\n" +
                            "1. In a skillet, cook the ground beef over medium heat until browned.\n" +
                            "2. Drain excess fat and stir in the taco seasoning.\n" +
                            "3. Warm the tortillas in a separate skillet or in the microwave.\n" +
                            "4. Place a spoonful of the seasoned ground beef onto each tortilla.\n" +
                            "5. Top with lettuce, shredded cheese, salsa, and any other desired toppings.\n" +
                            "6. Fold the tortillas over the filling to form tacos.\n" +
                            "7. Serve immediately and enjoy!",
                        Portions = 6,
                        PrepareTime = 25,
                        ImageData = ImgToByteArray("Models/images/beef_tacos.jpg")
                    },
                    new Recipe
                    {
                        Name = "Vegetable Stir-Fry",
                        Category = "Main Dish",
                        Description = "This vegetable stir-fry is a healthy and flavorful main dish. It features a mix of colorful vegetables, such as bell peppers, broccoli, carrots, and snap peas, stir-fried in a savory sauce.\n\n" +
                            "Ingredients:\n" +
                            "- Bell peppers (assorted colors)\n" +
                            "- Broccoli florets\n" +
                            "- Carrots\n" +
                            "- Snap peas\n" +
                            "- Garlic\n" +
                            "- Soy sauce\n" +
                            "- Sesame oil\n" +
                            "- Optional: ginger, chili flakes, cashews\n\n" +
                            "Steps:\n" +
                            "1. Heat sesame oil in a large skillet or wok over medium-high heat.\n" +
                            "2. Add minced garlic (and ginger if using) and sauté for about 1 minute.\n" +
                            "3. Add chopped bell peppers, broccoli florets, sliced carrots, and snap peas to the skillet.\n" +
                            "4. Stir-fry the vegetables for 4-5 minutes or until crisp-tender.\n" +
                            "5. In a small bowl, mix soy sauce and a splash of sesame oil.\n" +
                            "6. Pour the sauce over the vegetables and toss to coat.\n" +
                            "7. Optional: Sprinkle with chili flakes and top with cashews for added flavor and crunch.\n" +
                            "8. Serve the vegetable stir-fry over steamed rice or noodles.\n" +
                            "9. Enjoy!",
                        Portions = 4,
                        PrepareTime = 30,
                        ImageData = ImgToByteArray("Models/images/vegetable_stir_fry.jpg")
                    },
                    new Recipe
                    {
                        Name = "Garlic Mashed Potatoes",
                        Category = "Side Dish",
                        Description = "Garlic mashed potatoes are a classic side dish that pairs well with many main dishes. They are made by boiling potatoes until tender, mashing them with butter and garlic, and adding cream for creaminess.\n\n" +
                            "Ingredients:\n" +
                            "- Potatoes\n" +
                            "- Butter\n" +
                            "- Garlic cloves\n" +
                            "- Cream\n" +
                            "- Salt and pepper\n\n" +
                            "Steps:\n" +
                            "1. Peel and chop the potatoes into chunks.\n" +
                            "2. Boil the potatoes in a pot of salted water until tender.\n" +
                            "3. Drain the potatoes and return them to the pot.\n" +
                            "4. In a small saucepan, melt butter and sauté minced garlic until fragrant.\n" +
                            "5. Mash the potatoes with a potato masher or a fork.\n" +
                            "6. Pour the melted butter and garlic over the mashed potatoes.\n" +
                            "7. Add cream and season with salt and pepper.\n" +
                            "8. Mix well until creamy and smooth.\n" +
                            "9. Adjust seasoning if needed.\n" +
                            "10. Serve hot and enjoy!",
                        Portions = 6,
                        PrepareTime = 35,
                        ImageData = ImgToByteArray("Models/images/garlic_mashed_potatoes.jpg")
                    },
                    new Recipe
                    {
                        Name = "Roasted Brussels Sprouts",
                        Category = "Side Dish",
                        Description = "Roasted Brussels sprouts are a delicious and nutritious side dish. The Brussels sprouts are coated in olive oil, seasoned with salt and pepper, and roasted until crispy and caramelized.\n\n" +
                            "Ingredients:\n" +
                            "- Brussels sprouts\n" +
                            "- Olive oil\n" +
                            "- Salt\n" +
                            "- Pepper\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 400°F (200°C).\n" +
                            "2. Trim the ends of the Brussels sprouts and remove any outer leaves that are discolored.\n" +
                            "3. Cut the Brussels sprouts in half.\n" +
                            "4. Place the halved Brussels sprouts on a baking sheet.\n" +
                            "5. Drizzle with olive oil and sprinkle with salt and pepper.\n" +
                            "6. Toss to coat the Brussels sprouts evenly.\n" +
                            "7. Roast in the preheated oven for 20-25 minutes or until crispy and caramelized.\n" +
                            "8. Stir or shake the pan halfway through cooking for even browning.\n" +
                            "9. Serve the roasted Brussels sprouts as a side dish.\n" +
                            "10. Enjoy!",
                        Portions = 4,
                        PrepareTime = 30,
                        ImageData = ImgToByteArray("Models/images/roasted_brussels_sprouts.jpg")
                    },
                    new Recipe
                    {
                        Name = "Chocolate Chip Cookies",
                        Category = "Dessert",
                        Description = "Chocolate chip cookies are a classic dessert loved by many. They are soft, chewy, and filled with delicious chocolate chips.\n\n" +
                            "Ingredients:\n" +
                            "- All-purpose flour\n" +
                            "- Baking soda\n" +
                            "- Salt\n" +
                            "- Unsalted butter\n" +
                            "- Granulated sugar\n" +
                            "- Brown sugar\n" +
                            "- Vanilla extract\n" +
                            "- Eggs\n" +
                            "- Chocolate chips\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 375°F (190°C).\n" +
                            "2. In a bowl, whisk together flour, baking soda, and salt.\n" +
                            "3. In a separate large bowl, cream together softened butter, granulated sugar, and brown sugar until creamy.\n" +
                            "4. Beat in eggs and vanilla extract until well combined.\n" +
                            "5. Gradually add the dry ingredients to the wet ingredients and mix until just combined.\n" +
                            "6. Stir in chocolate chips.\n" +
                            "7. Drop rounded spoonfuls of cookie dough onto a baking sheet.\n" +
                            "8. Bake for 9-11 minutes or until golden brown around the edges.\n" +
                            "9. Allow the cookies to cool on the baking sheet for a few minutes, then transfer to a wire rack to cool completely.\n" +
                            "10. Enjoy the chocolate chip cookies with a glass of milk!",
                        Portions = 24,
                        PrepareTime = 25,
                        ImageData = ImgToByteArray("Models/images/chocolate_chip_cookies.jpg")
                    },
                    new Recipe
                    {
                        Name = "Blueberry Cheesecake",
                        Category = "Dessert",
                        Description = "Blueberry cheesecake is a creamy and indulgent dessert with a sweet graham cracker crust, smooth cream cheese filling, and a luscious blueberry topping.\n\n" +
                            "Ingredients:\n" +
                            "- Graham crackers\n" +
                            "- Butter\n" +
                            "- Cream cheese\n" +
                            "- Sugar\n" +
                            "- Eggs\n" +
                            "- Vanilla extract\n" +
                            "- Blueberries\n" +
                            "- Lemon juice\n" +
                            "- Cornstarch\n" +
                            "- Whipped cream (optional)\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 325°F (160°C).\n" +
                            "2. Crush graham crackers and mix with melted butter to form the crust.\n" +
                            "3. Press the crust mixture into the bottom of a greased springform pan.\n" +
                            "4. In a mixing bowl, beat cream cheese, sugar, eggs, and vanilla extract until smooth.\n" +
                            "5. Pour the cream cheese mixture over the crust in the springform pan.\n" +
                            "6. Bake in the preheated oven for 50-60 minutes or until the center is set.\n" +
                            "7. In a saucepan, combine blueberries, lemon juice, and cornstarch.\n" +
                            "8. Cook over medium heat, stirring constantly, until the mixture thickens and the blueberries burst.\n" +
                            "9. Remove the cheesecake from the oven and let it cool.\n" +
                            "10. Once cooled, spread the blueberry topping over the cheesecake.\n" +
                            "11. Chill the cheesecake in the refrigerator for at least 4 hours or overnight.\n" +
                            "12. Serve slices of blueberry cheesecake with a dollop of whipped cream if desired.\n" +
                            "13. Enjoy the delicious blueberry cheesecake!",
                                            Portions = 8,
                                            PrepareTime = 60,
                                            ImageData = ImgToByteArray("Models/images/blueberry_cheesecake.jpg")
                                        },
                    new Recipe
                    {
                        Name = "Apple Crumble",
                        Category = "Dessert",
                        Description = "Apple crumble is a warm and comforting dessert made with tender apples and a crispy crumb topping. It's perfect for fall or anytime you crave a delicious sweet treat.\n\n" +
                            "Ingredients:\n" +
                            "- Apples\n" +
                            "- Lemon juice\n" +
                            "- Sugar\n" +
                            "- All-purpose flour\n" +
                            "- Rolled oats\n" +
                            "- Butter\n" +
                            "- Cinnamon\n" +
                            "- Nutmeg\n" +
                            "- Vanilla ice cream (optional)\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 375°F (190°C).\n" +
                            "2. Peel, core, and slice the apples.\n" +
                            "3. Toss the apple slices with lemon juice and sugar.\n" +
                            "4. In a separate bowl, combine flour, rolled oats, sugar, cinnamon, nutmeg, and softened butter.\n" +
                            "5. Mix the ingredients until they resemble coarse crumbs.\n" +
                            "6. Place the apple slices in a baking dish and sprinkle the crumble mixture on top.\n" +
                            "7. Bake in the preheated oven for 30-35 minutes or until the apples are tender and the topping is golden brown.\n" +
                            "8. Remove from the oven and let it cool slightly.\n" +
                            "9. Serve warm apple crumble with a scoop of vanilla ice cream if desired.\n" +
                            "10. Enjoy the delicious apple crumble dessert!",
                        Portions = 6,
                        PrepareTime = 45,
                        ImageData = ImgToByteArray("Models/images/apple_crumble.jpg")
                    },
                    new Recipe
                    {
                        Name = "Garlic Roasted Potatoes",
                        Category = "Side Dish",
                        Description = "Garlic roasted potatoes are a savory and flavorful side dish that pairs well with various main courses. They are crispy on the outside, soft on the inside, and infused with the delicious aroma of garlic.\n\n" +
                            "Ingredients:\n" +
                            "- Potatoes\n" +
                            "- Olive oil\n" +
                            "- Garlic cloves\n" +
                            "- Salt\n" +
                            "- Black pepper\n" +
                            "- Dried herbs (optional, such as rosemary or thyme)\n\n" +
                            "Steps:\n" +
                            "1. Preheat the oven to 425°F (220°C).\n" +
                            "2. Wash and scrub the potatoes, then cut them into bite-sized pieces.\n" +
                            "3. In a bowl, toss the potato pieces with olive oil, minced garlic cloves, salt, black pepper, and dried herbs if desired.\n" +
                            "4. Spread the seasoned potatoes in a single layer on a baking sheet.\n" +
                            "5. Roast in the preheated oven for 30-35 minutes or until the potatoes are golden brown and crispy.\n" +
                            "6. Remove from the oven and let them cool for a few minutes.\n" +
                            "7. Transfer the roasted potatoes to a serving dish.\n" +
                            "8. Garnish with fresh herbs if desired.\n" +
                            "9. Serve the garlic roasted potatoes as a delicious side dish.\n" +
                            "10. Enjoy!",
                        Portions = 4,
                        PrepareTime = 40,
                        ImageData = ImgToByteArray("Models/images/garlic_roasted_potatoes.jpg")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}