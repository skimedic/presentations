CREATE TABLE IF NOT EXISTS "Sponsors"(
  "Id" SERIAL PRIMARY KEY,
  "CompanyName" VARCHAR(255) UNIQUE NOT NULL,
  "Level" VARCHAR(10) NOT NULL,
  "Description" TEXT,
  "ContactName" VARCHAR(255),
  "ContactEmail" VARCHAR(255),
  "FinanceName" VARCHAR(255),
  "FinanceEmail" VARCHAR(255)
)