using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.Models.Entities;

namespace SpyStore_HOL.DAL.Initialization
{
    public static class StoreSampleData
    {
        public static IEnumerable<Category> GetCategories() => new List<Category>
        {
            new Category {CategoryName = "Communications"},
            new Category {CategoryName = "Deception"},
            new Category {CategoryName = "Travel"},
            new Category {CategoryName = "Protection"},
            new Category {CategoryName = "Munitions"},
            new Category {CategoryName = "Tools"},
            new Category {CategoryName = "General"}
        };
        public static IList<Product> GetProducts(IList<Category> categories)
        {
            var products = new List<Product>();
            foreach (var category in categories)
            {
                switch (category.CategoryName)
                {
                    case "Communications":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "RED1",
                                ModelName = "Communications Device",
                                UnitCost = 49.99M,
                                CurrentPrice = 49.99M,
                                Description =
                                    "Subversively stay in touch with this miniaturized wireless communications device. Speak into the pointy end and listen with the other end! Voice-activated dialing makes calling for backup a breeze. Excellent for undercover work at schools, rest homes, and most corporate headquarters. Comes in assorted colors.",
                                UnitsInStock = 2,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "LK4TLNT",
                                ModelName = "Persuasive Pencil",
                                UnitCost = 1.99M,
                                CurrentPrice = 1.99M,
                                Description =
                                    "Persuade anyone to see your point of view!  Captivate your friends and enemies alike!  Draw the crime-scene or map out the chain of events.  All you need is several years of training or copious amounts of natural talent. You're halfway there with the Persuasive Pencil. Purchase this item with the Retro Pocket Protector Rocket Pack for optimum disguise.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "LSRPTR1",
                                ModelName = "Nonexplosive Cigar",
                                UnitCost = 29.99M,
                                CurrentPrice = 29.99M,
                                Description =
                                    "Contrary to popular spy lore, not all cigars owned by spies explode! Best used during mission briefings, our Nonexplosive Cigar is really a cleverly-disguised, top-of-the-line, precision laser pointer. Make your next presentation a hit.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "TCKLR1",
                                ModelName = "Fake Moustache Translator",
                                UnitCost = 599.99M,
                                CurrentPrice = 599.99M,
                                Description =
                                    "Fake Moustache Translator attaches between nose and mouth to double as a language translator and identity concealer. Sophisticated electronics translate your voice into the desired language. Wriggle your nose to toggle between Spanish, English, French, and Arabic. Excellent on diplomatic missions.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "JWLTRANS6",
                                ModelName = "Interpreter Earrings",
                                UnitCost = 459.99M,
                                CurrentPrice = 459.99M,
                                Description =
                                    "The simple elegance of our stylish monosex earrings accents any wardrobe, but their clean lines mask the sophisticated technology within. Twist the lower half to engage a translator function that intercepts spoken words in any language and converts them to the wearer's native tongue. Warning: do not use in conjunction with our Fake Moustache Translator product, as the resulting feedback loop makes any language sound like Pig Latin.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "Deception":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "DNTGCGHT",
                                ModelName = "Counterfeit Creation Wallet",
                                UnitCost = 999.99M,
                                CurrentPrice = 999.99M,
                                Description =
                                    "Don't be caught penniless in Prague without this hot item! Instantly creates replicas of most common currencies! Simply place rocks and water in the wallet, close, open up again, and remove your legal tender!",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "CITSME9",
                                ModelName = "Cloaking Device",
                                UnitCost = 9999.99M,
                                CurrentPrice = 9999.99M,
                                Description =
                                    "Worried about detection on your covert mission? Confuse mission-threatening forces with this cloaking device. Powerful new features include string-activated pre-programmed phrases such as \"Danger! Danger!\", \"Reach for the sky!\", and other anti-enemy expressions. Hyper-reactive karate chop action deters even the most persistent villain.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "BME007",
                                ModelName = "Indentity Confusion Device",
                                UnitCost = 6.99M,
                                CurrentPrice = 6.99M,
                                Description =
                                    "Never leave on an undercover mission without our Identity Confusion Device! If a threatening person approaches, deploy the device and point toward the oncoming individual. The subject will fail to recognize you and let you pass unnoticed. Also works well on dogs.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "BHONST93",
                                ModelName = "Correction Fluid",
                                UnitCost = 1.99M,
                                CurrentPrice = 1.99M,
                                Description =
                                    "Disguised as typewriter correction fluid, this scientific truth serum forces subjects to correct anything not perfectly true. Simply place a drop of the special correction fluid on the tip of the subject's nose. Within seconds, the suspect will automatically correct every lie. Effects from Correction Fluid last approximately 30 minutes per drop. WARNING: Discontinue use if skin appears irritated.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "THNKDKE1",
                                ModelName = "Hologram Cufflinks",
                                UnitCost = 799.99M,
                                CurrentPrice = 799.99M,
                                Description =
                                    "Just point, and a turn of the wrist will project a hologram of you up to 100 yards away. Sneaking past guards will be child's play when you've sent them on a wild goose chase. Note: Hologram adds ten pounds to your appearance.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "Travel":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "RU007",
                                ModelName = "Rain Racer 2000",
                                UnitCost = 1499.99M,
                                CurrentPrice = 1499.99M,
                                Description =
                                    "Looks like an ordinary bumbershoot, but don't be fooled! Simply place Rain Racer's tip on the ground and press the release latch. Within seconds, this ordinary rain umbrella converts into a two-wheeled gas-powered mini-scooter. Goes from 0 to 60 in 7.5 seconds - even in a driving rain! Comes in black, blue, and candy-apple red.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "P38",
                                ModelName = "Escape Vehicle (Air)",
                                UnitCost = 2.99M,
                                CurrentPrice = 2.99M,
                                Description =
                                    "In a jam, need a quick escape? Just whip out a sheet of our patented P38 paper and, with a few quick folds, it converts into a lighter-than-air escape vehicle! Especially effective on windy days - no fuel required. Comes in several sizes including letter, legal, A10, and B52.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "PT109",
                                ModelName = "Escape Vehicle (Water)",
                                UnitCost = 1299.99M,
                                CurrentPrice = 1299.99M,
                                Description =
                                    "Camouflaged as stylish wing tips, these 'shoes' get you out of a jam on the high seas instantly. Exposed to water, the pair transforms into speedy miniature inflatable rafts. Complete with 76 HP outboard motor, these hip heels will whisk you to safety even in the roughest of seas. Warning: Not recommended for beachwear.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "DNTRPR",
                                ModelName = "Toaster Boat",
                                UnitCost = 19999.98M,
                                CurrentPrice = 19999.98M,
                                Description =
                                    "Turn breakfast into a high-speed chase! In addition to toasting bagels and breakfast pastries, this inconspicuous toaster turns into a speedboat at the touch of a button. Boasting top speeds of 60 knots and an ultra-quiet motor, this valuable item will get you where you need to be ... fast! Best of all, Toaster Boat is easily repaired using a Versatile Paperclip or a standard butter knife. Manufacturer's Warning: Do not submerge electrical items.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "WRLD00",
                                ModelName = "Global Navigational System",
                                UnitCost = 29.99M,
                                CurrentPrice = 29.99M,
                                Description =
                                    "No spy should be without one of these premium devices. Determine your exact location with a quick flick of the finger. Calculate destination points by spinning, closing your eyes, and stopping it with your index finger.",
                                UnitsInStock = 1,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "LNGWADN",
                                ModelName = "Escape Cord",
                                UnitCost = 13.99M,
                                CurrentPrice = 13.99M,
                                Description =
                                    "Any agent assigned to mountain terrain should carry this ordinary-looking extension cord ... except that it's really a rappelling rope! Pull quickly on each end to convert the electrical cord into a rope capable of safely supporting up to two agents. Comes in various sizes including Mt McKinley, Everest, and Kilimanjaro. WARNING: To prevent serious injury, be sure to disconnect from wall socket before use.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "Protection":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "TGFDA",
                                ModelName = "Multi-Purpose Towelette",
                                UnitCost = 12.99M,
                                CurrentPrice = 12.99M,
                                Description =
                                    "Don't leave home without your monogrammed towelette! Made from lightweight, quick-dry fabric, this piece of equipment has more uses in a spy's day than a Swiss Army knife. The perfect all-around tool while undercover in the locker room: serves as towel, shield, disguise, sled, defensive weapon, whip and emergency food source. Handy bail gear for the Toaster Boat. Monogram included with purchase price.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "LKARCKT",
                                ModelName = "Pocket Protector Rocket Pack",
                                UnitCost = 1.99M,
                                CurrentPrice = 1.99M,
                                Description =
                                    "Any debonair spy knows that this accoutrement is coming back in style. Flawlessly protects the pockets of your short-sleeved oxford from unsightly ink and pencil marks. But there's more! Strap it on your back and it doubles as a rocket pack. Provides enough turbo-thrust for a 250-pound spy or a passel of small children. Maximum travel radius: 3000 miles.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "SQUKY1",
                                ModelName = "Guard Dog Pacifier",
                                UnitCost = 14.99M,
                                CurrentPrice = 14.99M,
                                Description =
                                    "Pesky guard dogs become a spy's best friend with the Guard Dog Pacifier. Even the most ferocious dogs suddenly act like cuddly kittens when they see this prop.  Simply hold the device in front of any threatening dogs, shaking it mildly.  For tougher canines, a quick squeeze emits an irresistible squeak that never fails to  place the dog under your control.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "SHADE01",
                                ModelName = "Ultra Violet Attack Defender",
                                UnitCost = 89.99M,
                                CurrentPrice = 89.99M,
                                Description =
                                    "Be safe and suave. A spy wearing this trendy article of clothing is safe from ultraviolet ray-gun attacks. Worn correctly, the Defender deflects rays from ultraviolet weapons back to the instigator. As a bonus, also offers protection against harmful solar ultraviolet rays, equivalent to SPF 50.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "1MOR4ME",
                                ModelName = "Cocktail Party Pal",
                                UnitCost = 69.99M,
                                CurrentPrice = 69.99M,
                                Description =
                                    "Do your assignments have you flitting from one high society party to the next? Worried about keeping your wits about you as you mingle witih the champagne-and-caviar crowd? No matter how many drinks you're offered, you can safely operate even the most complicated heavy machinery as long as you use our model 1MOR4ME alcohol-neutralizing coaster. Simply place the beverage glass on the patented circle to eliminate any trace of alcohol in the drink.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "BSUR2DUC",
                                ModelName = "Bullet Proof Facial Tissue",
                                UnitCost = 79.99M,
                                CurrentPrice = 79.99M,
                                Description =
                                    "Being a spy can be dangerous work. Our patented Bulletproof Facial Tissue gives a spy confidence that any bullets in the vicinity risk-free. Unlike traditional bulletproof devices, these lightweight tissues have amazingly high tensile strength. To protect the upper body, simply place a tissue in your shirt pocket. To protect the lower body, place a tissue in your pants pocket. If you do not have any pockets, be sure to check out our Bulletproof Tape. 100 tissues per box. WARNING: Bullet must not be moving for device to successfully stop penetration.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "Munitions":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "NTMBS1",
                                ModelName = "Multi-Purpose Rubber Band",
                                UnitCost = 1.99M,
                                CurrentPrice = 1.99M,
                                Description =
                                    "One of our most popular items!  A band of rubber that stretches  20 times the original size. Uses include silent one-to-one communication across a crowded room, holding together a pack of Persuasive Pencils, and powering lightweight aircraft. Beware, stretching past 20 feet results in a painful snap and a rubber strip.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "INCPPRCLP",
                                ModelName = "The Incredible Versatile Paperclip",
                                UnitCost = 1.49M,
                                CurrentPrice = 1.49M,
                                Description =
                                    "This 0. 01 oz piece of metal is the most versatile item in any respectable spy's toolbox and will come in handy in all sorts of situations. Serves as a wily lock pick, aerodynamic projectile (used in conjunction with Multi-Purpose Rubber Band), or escape-proof finger cuffs.  Best of all, small size and pliability means it fits anywhere undetected.  Order several today!",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "WOWPEN",
                                ModelName = "Mighty Mighty Pen",
                                UnitCost = 129.99M,
                                CurrentPrice = 129.99M,
                                Description =
                                    "Some spies claim this item is more powerful than a sword. After examining the titanium frame, built-in blowtorch, and Nerf dart-launcher, we tend to agree! ",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "Tools":
                        products.AddRange(new List<Product>
                        {
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "NOZ119",
                                ModelName = "Extracting Tool",
                                UnitCost = 199M,
                                CurrentPrice = 199M,
                                Description =
                                    "High-tech miniaturized extracting tool. Excellent for extricating foreign objects from your person. Good for picking up really tiny stuff, too! Cleverly disguised as a pair of tweezers. ",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "NE1RPR",
                                ModelName = "Universal Repair System",
                                UnitCost = 4.99M,
                                CurrentPrice = 4.99M,
                                Description =
                                    "Few people appreciate the awesome repair possibilities contained in a single roll of duct tape. In fact, some houses in the Midwest are made entirely out of the miracle material contained in every roll! Can be safely used to repair cars, computers, people, dams, and a host of other items.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "BRTLGT1",
                                ModelName = "Effective Flashlight",
                                UnitCost = 9.99M,
                                CurrentPrice = 9.99M,
                                Description =
                                    "The most powerful darkness-removal device offered to creatures of this world.  Rather than amplifying existing/secondary light, this handy product actually REMOVES darkness allowing you to see with your own eyes.  Must-have for nighttime operations. An affordable alternative to the Night Vision Goggles.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "FF007",
                                ModelName = "Eavesdrop Detector",
                                UnitCost = 99.99M,
                                CurrentPrice = 99.99M,
                                Description =
                                    "Worried that counteragents have placed listening devices in your home or office? No problem! Use our bug-sweeping wiener to check your surroundings for unwanted surveillance devices. Just wave the frankfurter around the room ... when bugs are detected, this \"foot-long\" beeps! Comes complete with bun, relish, mustard, and headphones for privacy.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "ULOST007",
                                ModelName = "Rubber Stamp Beacon",
                                UnitCost = 129.99M,
                                CurrentPrice = 129.99M,
                                Description =
                                    "With the Rubber Stamp Beacon, you'll never get lost on your missions again. As you proceed through complicated terrain, stamp a stationary object with this device. Once an object has been stamped, the stamp's patented ink will emit a signal that can be detected up to 153.2 miles away by the receiver embedded in the device's case. WARNING: Do not expose ink to water.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "BPRECISE00",
                                ModelName = "Dilemma Resolution Device",
                                UnitCost = 11.99M,
                                CurrentPrice = 11.99M,
                                Description =
                                    "Facing a brick wall? Stopped short at a long, sheer cliff wall?  Carry our handy lightweight calculator for just these emergencies. Quickly enter in your dilemma and the calculator spews out the best solutions to the problem.   Manufacturer Warning: Use at own risk. Suggestions may lead to adverse outcomes.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "GRTWTCH9",
                                ModelName = "Multi-Purpose Watch",
                                UnitCost = 399.99M,
                                CurrentPrice = 399.99M,
                                Description =
                                    "In the tradition of famous spy movies, the Multi Purpose Watch comes with every convenience! Installed with lighter, TV, camera, schedule-organizing software, MP3 player, water purifier, spotlight, and tire pump. Special feature: Displays current date and time. Kitchen sink add-on will be available in the fall of 2001.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    case "General":
                        products.AddRange(new List<Product>
                        {

                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "STKY1",
                                ModelName = "Edible Tape",
                                UnitCost = 3.99M,
                                CurrentPrice = 3.99M,
                                Description =
                                    "The latest in personal survival gear, the STKY1 looks like a roll of ordinary office tape, but can save your life in an emergency.  Just remove the tape roll and place in a kettle of boiling water with mixed vegetables and a ham shank. In just 90 minutes you have a great tasking soup that really sticks to your ribs! Herbs and spices not included.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "ICNCU",
                                ModelName = "Perfect-Vision Glasses",
                                UnitCost = 129.99M,
                                CurrentPrice = 129.99M,
                                Description =
                                    "Avoid painful and potentially devastating laser eye surgery and contact lenses. Cheaper and more effective than a visit to the optometrist, these Perfect-Vision Glasses simply slide over nose and eyes and hook on ears. Suddenly you have 20/20 vision! Glasses also function as HUD (Heads Up Display) for most European sports cars manufactured after 1992.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "CHEW99",
                                ModelName = "Survival Bar",
                                UnitCost = 6.99M,
                                CurrentPrice = 6.99M,
                                Description =
                                    "Survive for up to four days in confinement with this handy item. Disguised as a common eraser, it's really a high-calorie food bar. Stranded in hostile territory without hope of nourishment? Simply break off a small piece of the eraser and chew vigorously for at least twenty minutes. Developed by the same folks who created freeze-dried ice cream, powdered drink mix, and glow-in-the-dark shoelaces.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "SQRTME1",
                                ModelName = "Remote Foliage Feeder",
                                UnitCost = 9.99M,
                                CurrentPrice = 9.99M,
                                Description =
                                    "Even spies need to care for their office plants.  With this handy remote watering device, you can water your flowers as a spy should, from the comfort of your chair.  Water your plants from up to 50 feet away.  Comes with an optional aiming system that can be mounted to the top for improved accuracy.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "ICUCLRLY00",
                                ModelName = "Contact Lenses",
                                UnitCost = 59.99M,
                                CurrentPrice = 59.99M,
                                Description =
                                    "Traditional binoculars and night goggles can be bulky, especially for assignments in confined areas. The problem is solved with these patent-pending contact lenses, which give excellent visibility up to 100 miles. New feature: now with a night vision feature that permits you to see in complete darkness! Contacts now come in a variety of fashionable colors for coordinating with your favorite ensembles.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "OPNURMIND",
                                ModelName = "Telekinesis Spoon",
                                UnitCost = 2.99M,
                                CurrentPrice = 2.99M,
                                Description =
                                    "Learn to move things with your mind! Broaden your mental powers using this training device to hone telekinesis skills. Simply look at the device, concentrate, and repeat \"There is no spoon\" over and over.",
                                UnitsInStock = 5,
                                IsFeatured = true
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "NOBOOBOO4U",
                                ModelName = "Speed Bandages",
                                UnitCost = 3.99M,
                                CurrentPrice = 3.99M,
                                Description =
                                    "Even spies make mistakes.  Barbed wire and guard dogs pose a threat of injury for the active spy.  Use our special bandages on cuts and bruises to rapidly heal the injury.  Depending on the severity of the wound, the bandages can take between 10 to 30 minutes to completely heal the injury.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "QLT2112",
                                ModelName = "Document Transportation System",
                                UnitCost = 299.99M,
                                CurrentPrice = 299.99M,
                                Description =
                                    "Keep your stolen Top Secret documents in a place they'll never think to look!  This patent leather briefcase has multiple pockets to keep documents organized.  Top quality craftsmanship to last a lifetime.",
                                UnitsInStock = 5,
                            },
                            new Product
                            {
                                Category = category,
                                CategoryId = category.Id,
                                ProductImage = "product-image.png",
                                ProductImageLarge = "product-image-lg.png",
                                ProductImageThumb = "product-thumb.png",
                                ModelNumber = "C00LCMB1",
                                ModelName = "Telescoping Comb",
                                UnitCost = 399.99M,
                                CurrentPrice = 399.99M,
                                Description =
                                    "Use the Telescoping Comb to track down anyone, anywhere! Deceptively simple, this is no normal comb. Flip the hidden switch and two telescoping lenses project forward creating a surprisingly powerful set of binoculars (50X). Night-vision add-on is available for midnight hour operations.",
                                UnitsInStock = 5,
                            },
                        });
                        break;
                    default:
                        break;
                }
            }
            return products;
        }

        public static IEnumerable<Customer> GetAllCustomerRecords(StoreContext context) => new List<Customer>
        {
            new Customer()
            {
                EmailAddress = "spy@secrets.com",
                Password = "Foo",
                FullName = "Super Spy",
            }
        };

        public static List<Order> GetOrders(Customer customer, StoreContext context) => new List<Order>
        {
            new Order()
            {
                Customer = customer,
                OrderDate = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0)),
                ShipDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
            }
        };
        public static List<OrderDetail> GetOrderDetails(
            Order order, StoreContext context)
        {
            var prod1 = context.Categories
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(3).FirstOrDefault();
            var prod2 = context.Categories.Skip(2)
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(2).FirstOrDefault();
            var prod3 = context.Categories.Skip(5)
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(1).FirstOrDefault();
            return new List<OrderDetail>
            {
                new OrderDetail() {Order = order, Product = prod1, Quantity = 3, UnitCost = prod1.CurrentPrice},
                new OrderDetail() {Order = order, Product = prod2, Quantity = 2, UnitCost = prod2.CurrentPrice},
                new OrderDetail() {Order = order, Product = prod3, Quantity = 5, UnitCost = prod3.CurrentPrice},
            };
        }

        public static List<OrderDetail> GetOrderDetails(
            StoreContext context)
        {
            var prod1 = context.Categories
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(3).FirstOrDefault();
            var prod2 = context.Categories.Skip(2)
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(2).FirstOrDefault();
            var prod3 = context.Categories.Skip(5)
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(1).FirstOrDefault();
            return new List<OrderDetail>
            {
                new OrderDetail() {Product = prod1, Quantity = 3, UnitCost = prod1.CurrentPrice},
                new OrderDetail() {Product = prod2, Quantity = 2, UnitCost = prod2.CurrentPrice},
                new OrderDetail() {Product = prod3, Quantity = 5, UnitCost = prod3.CurrentPrice},
            };
        }

        public static IList<ShoppingCartRecord> GetCart(
            Customer customer, StoreContext context)
        {
            var prod1 = context.Categories.Skip(2)
                .Include(c => c.Products).FirstOrDefault()?
                .Products.Skip(1).FirstOrDefault();
            return new List<ShoppingCartRecord>
            {
                new ShoppingCartRecord {
                    Customer = customer, DateCreated = DateTime.Now,
                    Product = prod1, Quantity = 1}
            };
        }

    }
}