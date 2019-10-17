Feature: Prepare book catalog
	prepare catalog with a list of books required for manual testing


Scenario: Setup basic example books
	Given the following books
         | Author                         | Title                          | Price |
         | Gojko Adzic                    | Bridging the Communication Gap | 12.20 |
         | Gojko Adzic                    | Specification By Example       | 15.30 |
         | Lisa Crispin and Janet Gregory | Agile Testing                  | 20.20 |
         | Mitch Lacey                    | The Scrum Field Guide          | 15.31 |
         | Martin Fowler                  | Refactoring                    | 29.55 |
         | Esther Derby and Diana Larsen  | Agile Retrospectives           | 16.99 |
         | Matt Wynne and Aslak Hellesoy  | The Cucumber Book              | 18.00 |
         | David Chelimsky                | The RSpec Book                 | 17.50 |