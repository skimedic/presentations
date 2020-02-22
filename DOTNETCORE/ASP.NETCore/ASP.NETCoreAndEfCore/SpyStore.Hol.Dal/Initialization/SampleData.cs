using System;
using System.Collections.Generic;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Dal.Initialization
{
    public static class SampleData
    {
        public static IEnumerable<Product> GetProducts() =>
            new List<Product>()
            {
                    new Product
                    {
                        CategoryId = 1,
                        Id = 1,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Communications Device",
                            Description =
                                "Subversively stay in touch with this miniaturized wireless communications device. Speak into the pointy end and listen with the other end! Voice-activated dialing makes calling for backup a breeze. Excellent for undercover work at schools, rest homes, and most corporate headquarters. Comes in assorted colors.",
                            ModelNumber = "RED1",
                        },
                        UnitCost = 49.99M,
                        CurrentPrice = 49.99M,
                        UnitsInStock = 2,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 1,
                        Id = 2,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Persuasive Pencil",
                            Description =
                                "Persuade anyone to see your point of view!  Captivate your friends and enemies alike!  Draw the crime-scene or map out the chain of events.  All you need is several years of training or copious amounts of natural talent. You're halfway there with the Persuasive Pencil. Purchase this item with the Retro Pocket Protector Rocket Pack for optimum disguise.",
                            ModelNumber = "LK4TLNT",
                        },
                        UnitCost = 1.99M,
                        CurrentPrice = 1.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 1,
                        Id = 3,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Nonexplosive Cigar",
                            Description =
                                "Contrary to popular spy lore, not all cigars owned by spies explode! Best used during mission briefings, our Nonexplosive Cigar is really a cleverly-disguised, top-of-the-line, precision laser pointer. Make your next presentation a hit.",
                            ModelNumber = "LSRPTR1",
                        },
                        UnitCost = 29.99M,
                        CurrentPrice = 29.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 1,
                        Id = 4,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Fake Moustache Translator",
                            Description =
                                "Fake Moustache Translator attaches between nose and mouth to double as a language translator and identity concealer. Sophisticated electronics translate your voice into the desired language. Wriggle your nose to toggle between Spanish, English, French, and Arabic. Excellent on diplomatic missions.",
                            ModelNumber = "TCKLR1",
                        },
                        UnitCost = 599.99M,
                        CurrentPrice = 599.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 1,
                        Id = 5,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Interpreter Earrings",
                            Description =
                                "The simple elegance of our stylish monosex earrings accents any wardrobe, but their clean lines mask the sophisticated technology within. Twist the lower half to engage a translator function that intercepts spoken words in any language and converts them to the wearer's native tongue. Warning: do not use in conjunction with our Fake Moustache Translator product, as the resulting feedback loop makes any language sound like Pig Latin.",
                            ModelNumber = "JWLTRANS6",
                        },
                        UnitCost = 459.99M,
                        CurrentPrice = 459.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 2,
                        Id = 6,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Counterfeit Creation Wallet",
                            Description =
                                "Don't be caught penniless in Prague without this hot item! Instantly creates replicas of most common currencies! Simply place rocks and water in the wallet, close, open up again, and remove your legal tender!",
                            ModelNumber = "DNTGCGHT",
                        },
                        UnitCost = 999.99M,
                        CurrentPrice = 999.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 2,
                        Id = 7,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Cloaking Device",
                            Description =
                                "Worried about detection on your covert mission? Confuse mission-threatening forces with this cloaking device. Powerful new features include string-activated pre-programmed phrases such as \"Danger! Danger!\", \"Reach for the sky!\", and other anti-enemy expressions. Hyper-reactive karate chop action deters even the most persistent villain.",
                            ModelNumber = "CITSME9",
                        },
                        UnitCost = 9999.99M,
                        CurrentPrice = 9999.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 2,
                        Id = 8,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Indentity Confusion Device",
                            Description =
                                "Never leave on an undercover mission without our Identity Confusion Device! If a threatening person approaches, deploy the device and point toward the oncoming individual. The subject will fail to recognize you and let you pass unnoticed. Also works well on dogs.",
                            ModelNumber = "BME007",
                        },
                        UnitCost = 6.99M,
                        CurrentPrice = 6.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 2,
                        Id = 9,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Correction Fluid",
                            Description =
                                "Disguised as typewriter correction fluid, this scientific truth serum forces subjects to correct anything not perfectly true. Simply place a drop of the special correction fluid on the tip of the subject's nose. Within seconds, the suspect will automatically correct every lie. Effects from Correction Fluid last approximately 30 minutes per drop. WARNING: Discontinue use if skin appears irritated.",
                            ModelNumber = "BHONST93",
                        },
                        UnitCost = 1.99M,
                        CurrentPrice = 1.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 2,
                        Id = 10,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Hologram Cufflinks",
                            Description =
                                "Just point, and a turn of the wrist will project a hologram of you up to 100 yards away. Sneaking past guards will be child's play when you've sent them on a wild goose chase. Note: Hologram adds ten pounds to your appearance.",
                            ModelNumber = "THNKDKE1",
                        },
                        UnitCost = 799.99M,
                        CurrentPrice = 799.99M,
                        UnitsInStock = 5,
                    },
                                        new Product
                    {
                        CategoryId = 3,
                        Id = 11,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Rain Racer 2000",
                            Description =
                                "Looks like an ordinary bumbershoot, but don't be fooled! Simply place Rain Racer's tip on the ground and press the release latch. Within seconds, this ordinary rain umbrella converts into a two-wheeled gas-powered mini-scooter. Goes from 0 to 60 in 7.5 seconds - even in a driving rain! Comes in black, blue, and candy-apple red.",
                            ModelNumber = "RU007",
                        },
                        UnitCost = 1499.99M,
                        CurrentPrice = 1499.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 3,
                        Id = 12,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Escape Vehicle (Air)",
                            Description =
                                "In a jam, need a quick escape? Just whip out a sheet of our patented P38 paper and, with a few quick folds, it converts into a lighter-than-air escape vehicle! Especially effective on windy days - no fuel required. Comes in several sizes including letter, legal, A10, and B52.",
                            ModelNumber = "P38",
                        },
                        UnitCost = 2.99M,
                        CurrentPrice = 2.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 3,
                        Id = 13,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Escape Vehicle (Water)",
                            Description =
                                "Camouflaged as stylish wing tips, these 'shoes' get you out of a jam on the high seas instantly. Exposed to water, the pair transforms into speedy miniature inflatable rafts. Complete with 76 HP outboard motor, these hip heels will whisk you to safety even in the roughest of seas. Warning: Not recommended for beachwear.",
                            ModelNumber = "PT109",
                        },
                        UnitCost = 1299.99M,
                        CurrentPrice = 1299.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 3,
                        Id = 14,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Toaster Boat",
                            Description =
                                "Turn breakfast into a high-speed chase! In addition to toasting bagels and breakfast pastries, this inconspicuous toaster turns into a speedboat at the touch of a button. Boasting top speeds of 60 knots and an ultra-quiet motor, this valuable item will get you where you need to be ... fast! Best of all, Toaster Boat is easily repaired using a Versatile Paperclip or a standard butter knife. Manufacturer's Warning: Do not submerge electrical items.",
                            ModelNumber = "DNTRPR",
                        },
                        UnitCost = 19999.98M,
                        CurrentPrice = 19999.98M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 3,
                        Id = 15,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Global Navigational System",
                            Description =
                                "No spy should be without one of these premium devices. Determine your exact location with a quick flick of the finger. Calculate destination points by spinning, closing your eyes, and stopping it with your index finger.",
                            ModelNumber = "WRLD00",
                        },
                        UnitCost = 29.99M,
                        CurrentPrice = 29.99M,
                        UnitsInStock = 1,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 3,
                        Id = 16,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Escape Cord",
                            Description =
                                "Any agent assigned to mountain terrain should carry this ordinary-looking extension cord ... except that it's really a rappelling rope! Pull quickly on each end to convert the electrical cord into a rope capable of safely supporting up to two agents. Comes in various sizes including Mt McKinley, Everest, and Kilimanjaro. WARNING: To prevent serious injury, be sure to disconnect from wall socket before use.",
                            ModelNumber = "LNGWADN",
                        },
                        UnitCost = 13.99M,
                        CurrentPrice = 13.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 17,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Multi-Purpose Towelette",
                            Description =
                                "Don't leave home without your monogrammed towelette! Made from lightweight, quick-dry fabric, this piece of equipment has more uses in a spy's day than a Swiss Army knife. The perfect all-around tool while undercover in the locker room: serves as towel, shield, disguise, sled, defensive weapon, whip and emergency food source. Handy bail gear for the Toaster Boat. Monogram included with purchase price.",
                            ModelNumber = "TGFDA",
                        },
                        UnitCost = 12.99M,
                        CurrentPrice = 12.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 18,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Pocket Protector Rocket Pack",
                            Description =
                                "Any debonair spy knows that this accoutrement is coming back in style. Flawlessly protects the pockets of your short-sleeved oxford from unsightly ink and pencil marks. But there's more! Strap it on your back and it doubles as a rocket pack. Provides enough turbo-thrust for a 250-pound spy or a passel of small children. Maximum travel radius: 3000 miles.",
                            ModelNumber = "LKARCKT",
                        },
                        UnitCost = 1.99M,
                        CurrentPrice = 1.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 19,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Guard Dog Pacifier",
                            Description =
                                "Pesky guard dogs become a spy's best friend with the Guard Dog Pacifier. Even the most ferocious dogs suddenly act like cuddly kittens when they see this prop.  Simply hold the device in front of any threatening dogs, shaking it mildly.  For tougher canines, a quick squeeze emits an irresistible squeak that never fails to  place the dog under your control.",
                            ModelNumber = "SQUKY1",
                        },
                        UnitCost = 14.99M,
                        CurrentPrice = 14.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 20,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Ultra Violet Attack Defender",
                            Description =
                                "Be safe and suave. A spy wearing this trendy article of clothing is safe from ultraviolet ray-gun attacks. Worn correctly, the Defender deflects rays from ultraviolet weapons back to the instigator. As a bonus, also offers protection against harmful solar ultraviolet rays, equivalent to SPF 50.",
                            ModelNumber = "SHADE01",
                        },
                        UnitCost = 89.99M,
                        CurrentPrice = 89.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 21,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Cocktail Party Pal",
                            Description =
                                "Do your assignments have you flitting from one high society party to the next? Worried about keeping your wits about you as you mingle witih the champagne-and-caviar crowd? No matter how many drinks you're offered, you can safely operate even the most complicated heavy machinery as long as you use our model 1MOR4ME alcohol-neutralizing coaster. Simply place the beverage glass on the patented circle to eliminate any trace of alcohol in the drink.",
                            ModelNumber = "1MOR4ME",
                        },
                        UnitCost = 69.99M,
                        CurrentPrice = 69.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 4,
                        Id = 22,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Bullet Proof Facial Tissue",
                            Description =
                                "Being a spy can be dangerous work. Our patented Bulletproof Facial Tissue gives a spy confidence that any bullets in the vicinity risk-free. Unlike traditional bulletproof devices, these lightweight tissues have amazingly high tensile strength. To protect the upper body, simply place a tissue in your shirt pocket. To protect the lower body, place a tissue in your pants pocket. If you do not have any pockets, be sure to check out our Bulletproof Tape. 100 tissues per box. WARNING: Bullet must not be moving for device to successfully stop penetration.",
                            ModelNumber = "BSUR2DUC",
                        },
                        UnitCost = 79.99M,
                        CurrentPrice = 79.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 5,
                        Id = 23,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Multi-Purpose Rubber Band",
                            Description =
                                "One of our most popular items!  A band of rubber that stretches  20 times the original size. Uses include silent one-to-one communication across a crowded room, holding together a pack of Persuasive Pencils, and powering lightweight aircraft. Beware, stretching past 20 feet results in a painful snap and a rubber strip.",
                            ModelNumber = "NTMBS1",
                        },
                        UnitCost = 1.99M,
                        CurrentPrice = 1.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 5,
                        Id = 24,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "The Incredible Versatile Paperclip",
                            Description =
                                "This 0. 01 oz piece of metal is the most versatile item in any respectable spy's toolbox and will come in handy in all sorts of situations. Serves as a wily lock pick, aerodynamic projectile (used in conjunction with Multi-Purpose Rubber Band), or escape-proof finger cuffs.  Best of all, small size and pliability means it fits anywhere undetected.  Order several today!",
                            ModelNumber = "INCPPRCLP",
                        },
                        UnitCost = 1.49M,
                        CurrentPrice = 1.49M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 5,
                        Id = 25,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Mighty Mighty Pen",
                            Description =
                                "Some spies claim this item is more powerful than a sword. After examining the titanium frame, built-in blowtorch, and Nerf dart-launcher, we tend to agree! ",
                            ModelNumber = "WOWPEN",
                        },
                        UnitCost = 129.99M,
                        CurrentPrice = 129.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 26,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Extracting Tool",
                            Description =
                                "High-tech miniaturized extracting tool. Excellent for extricating foreign objects from your person. Good for picking up really tiny stuff, too! Cleverly disguised as a pair of tweezers. ",
                            ModelNumber = "NOZ119",
                        },
                        UnitCost = 199M,
                        CurrentPrice = 199M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 27,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Universal Repair System",
                            Description =
                                "Few people appreciate the awesome repair possibilities contained in a single roll of duct tape. In fact, some houses in the Midwest are made entirely out of the miracle material contained in every roll! Can be safely used to repair cars, computers, people, dams, and a host of other items.",
                            ModelNumber = "NE1RPR",
                        },
                        UnitCost = 4.99M,
                        CurrentPrice = 4.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 28,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Effective Flashlight",
                            Description =
                                "The most powerful darkness-removal device offered to creatures of this world.  Rather than amplifying existing/secondary light, this handy product actually REMOVES darkness allowing you to see with your own eyes.  Must-have for nighttime operations. An affordable alternative to the Night Vision Goggles.",
                            ModelNumber = "BRTLGT1",
                        },
                        UnitCost = 9.99M,
                        CurrentPrice = 9.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 29,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Eavesdrop Detector",
                            Description =
                                "Worried that counteragents have placed listening devices in your home or office? No problem! Use our bug-sweeping wiener to check your surroundings for unwanted surveillance devices. Just wave the frankfurter around the room ... when bugs are detected, this \"foot-long\" beeps! Comes complete with bun, relish, mustard, and headphones for privacy.",
                            ModelNumber = "FF007",
                        },
                        UnitCost = 99.99M,
                        CurrentPrice = 99.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 30,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Rubber Stamp Beacon",
                            Description =
                                "With the Rubber Stamp Beacon, you'll never get lost on your missions again. As you proceed through complicated terrain, stamp a stationary object with this device. Once an object has been stamped, the stamp's patented ink will emit a signal that can be detected up to 153.2 miles away by the receiver embedded in the device's case. WARNING: Do not expose ink to water.",
                            ModelNumber = "ULOST007",
                        },
                        UnitCost = 129.99M,
                        CurrentPrice = 129.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 31,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Dilemma Resolution Device",
                            Description =
                                "Facing a brick wall? Stopped short at a long, sheer cliff wall?  Carry our handy lightweight calculator for just these emergencies. Quickly enter in your dilemma and the calculator spews out the best solutions to the problem.   Manufacturer Warning: Use at own risk. Suggestions may lead to adverse outcomes.",
                            ModelNumber = "BPRECISE00",
                        },
                        UnitCost = 11.99M,
                        CurrentPrice = 11.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 6,
                        Id = 32,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Multi-Purpose Watch",
                            Description =
                                "In the tradition of famous spy movies, the Multi Purpose Watch comes with every convenience! Installed with lighter, TV, camera, schedule-organizing software, MP3 player, water purifier, spotlight, and tire pump. Special feature: Displays current date and time. Kitchen sink add-on will be available in the fall of 2001.",
                            ModelNumber = "GRTWTCH9",
                        },
                        UnitCost = 399.99M,
                        CurrentPrice = 399.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 33,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Edible Tape",
                            Description =
                                "The latest in personal survival gear, the STKY1 looks like a roll of ordinary office tape, but can save your life in an emergency.  Just remove the tape roll and place in a kettle of boiling water with mixed vegetables and a ham shank. In just 90 minutes you have a great tasking soup that really sticks to your ribs! Herbs and spices not included.",
                            ModelNumber = "STKY1",
                        },
                        UnitCost = 3.99M,
                        CurrentPrice = 3.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 34,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Perfect-Vision Glasses",
                            Description =
                                "Avoid painful and potentially devastating laser eye surgery and contact lenses. Cheaper and more effective than a visit to the optometrist, these Perfect-Vision Glasses simply slide over nose and eyes and hook on ears. Suddenly you have 20/20 vision! Glasses also function as HUD (Heads Up Display) for most European sports cars manufactured after 1992.",
                            ModelNumber = "ICNCU",
                        },
                        UnitCost = 129.99M,
                        CurrentPrice = 129.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 35,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Survival Bar",
                            Description =
                                "Survive for up to four days in confinement with this handy item. Disguised as a common eraser, it's really a high-calorie food bar. Stranded in hostile territory without hope of nourishment? Simply break off a small piece of the eraser and chew vigorously for at least twenty minutes. Developed by the same folks who created freeze-dried ice cream, powdered drink mix, and glow-in-the-dark shoelaces.",
                            ModelNumber = "CHEW99",
                        },
                        UnitCost = 6.99M,
                        CurrentPrice = 6.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 36,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Remote Foliage Feeder",
                            Description =
                                "Even spies need to care for their office plants.  With this handy remote watering device, you can water your flowers as a spy should, from the comfort of your chair.  Water your plants from up to 50 feet away.  Comes with an optional aiming system that can be mounted to the top for improved accuracy.",
                            ModelNumber = "SQRTME1",
                        },
                        UnitCost = 9.99M,
                        CurrentPrice = 9.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 37,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Contact Lenses",
                            Description =
                                "Traditional binoculars and night goggles can be bulky, especially for assignments in confined areas. The problem is solved with these patent-pending contact lenses, which give excellent visibility up to 100 miles. New feature: now with a night vision feature that permits you to see in complete darkness! Contacts now come in a variety of fashionable colors for coordinating with your favorite ensembles.",
                            ModelNumber = "ICUCLRLY00",
                        },
                        UnitCost = 59.99M,
                        CurrentPrice = 59.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 38,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Telekinesis Spoon",
                            Description =
                                "Learn to move things with your mind! Broaden your mental powers using this training device to hone telekinesis skills. Simply look at the device, concentrate, and repeat \"There is no spoon\" over and over.",
                            ModelNumber = "OPNURMIND",
                        },
                        UnitCost = 2.99M,
                        CurrentPrice = 2.99M,
                        UnitsInStock = 5,
                        IsFeatured = true
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 39,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Speed Bandages",
                            Description =
                                "Even spies make mistakes.  Barbed wire and guard dogs pose a threat of injury for the active spy.  Use our special bandages on cuts and bruises to rapidly heal the injury.  Depending on the severity of the wound, the bandages can take between 10 to 30 minutes to completely heal the injury.",
                            ModelNumber = "NOBOOBOO4U",
                        },
                        UnitCost = 3.99M,
                        CurrentPrice = 3.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 40,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Document Transportation System",
                            Description =
                                "Keep your stolen Top Secret documents in a place they'll never think to look!  This patent leather briefcase has multiple pockets to keep documents organized.  Top quality craftsmanship to last a lifetime.",
                            ModelNumber = "QLT2112",
                        },
                        UnitCost = 299.99M,
                        CurrentPrice = 299.99M,
                        UnitsInStock = 5,
                    },
                    new Product
                    {
                        CategoryId = 7,
                        Id = 41,
                        Details = new ProductDetails
                        {
                            ProductImage = "product-image.png",
                            ProductImageLarge = "product-image-lg.png",
                            ProductImageThumb = "product-thumb.png",
                            ModelName = "Telescoping Comb",
                            Description =
                                "Use the Telescoping Comb to track down anyone, anywhere! Deceptively simple, this is no normal comb. Flip the hidden switch and two telescoping lenses project forward creating a surprisingly powerful set of binoculars (50X). Night-vision add-on is available for midnight hour operations.",
                            ModelNumber = "C00LCMB1",
                        },
                        UnitCost = 399.99M,
                        CurrentPrice = 399.99M,
                        UnitsInStock = 5,
                    },
            };
        public static IEnumerable<Category> GetCategories() => 
            new List<Category>
        {
            new Category 
            { Id = 1,CategoryName = "Communications"},
            new Category
            {Id = 2,
                CategoryName = "Deception" },
            new Category
            {Id = 3,
                CategoryName = "Travel"},
            
            new Category
            { Id = 4,CategoryName = "Protection"},
            new Category
            {Id = 5,
                CategoryName = "Munitions" },
            new Category
            {Id = 6,
                CategoryName = "Tools"},
            new Category
            {Id = 7,
                CategoryName = "General"}
        };

        public static IList<Order> GetOrders() => new List<Order>
        {
            new Order()
            {
                Id = 1, CustomerId = 1,
                OrderDate = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0)),
                ShipDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
            }
        };


        public static IList<OrderDetail> GetOrderDetails(IList<Product> products) => new List<OrderDetail>
        {
            new OrderDetail()
            { 
                Id = 1, OrderId = 1,
                ProductNavigation = products[0], Quantity = 3, UnitCost = products[0].CurrentPrice
            },
            new OrderDetail()
            {
                Id = 2, OrderId = 1,
                ProductNavigation = products[1], Quantity = 2, UnitCost = products[1].CurrentPrice
            },
            new OrderDetail()
            {
                Id = 3, OrderId = 1,
                ProductNavigation = products[2], Quantity = 5, UnitCost = products[2].CurrentPrice
            },
        };

        public static IList<ShoppingCartRecord> GetCart(IList<Product> products)
        => new List<ShoppingCartRecord>
            {
                new ShoppingCartRecord
                {
                    Id = 1,
                    CustomerId = 1,
                    DateCreated = DateTime.Now,
                    ProductNavigation = products[0],
                    Quantity = 1,
                    LineItemTotal = products[0].CurrentPrice
                }
            };

    }
}