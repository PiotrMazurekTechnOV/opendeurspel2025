# Database

-- Queries Database

-- questions
 
-- Create questions information
INSERT INTO questions (id, location_id, text) VALUES (?, ?, ?);
 
-- Select questions informations
SELECT * FROM questions WHERE questions_id = ?;
 
-- Update questions informations
UPDATE questions SET id = ?, location_id = ?, text = ?;
 
-- Delete questions informations
DELETE FROM questions WHERE id = ?;

-- Get question based on location number
SELECT FROM questions.id, questions.location_id, questions.text
FROM questions
JOIN locations ON questions.location_id = location.id
WHERE locations.number = ?;


------------------------------------------------------------------------------------------------------------------------------------------------------

-- Get all answers based on question id        

SELECT *       
FROM opendeurspel2025.answers
WHERE answers.question_id = ?;


-- Create answers informations
INSERT INTO answers (id, text, correct, question_id) VALUES (?, ?, ?, ?);
 
-- Select answers informations
SELECT * FROM answers WHERE code = ?;
 
-- Update answers informations
UPDATE answers SET id = ?, text = ?, correct = ?, question_id = ?;
 
-- Delete answers informations
DELETE FROM answers WHERE id = ? AND text = ? AND correct = ? AND question_id = ?;


-------------------------------------------------------------------------------------------------------------------------------------------------------


-- locations



-- Create locations informations
INSERT INTO answers (id, number, name) VALUES (?, ?, ?)

-- Select locations informations
SELECT * FROM locations WHERE code = ?;

-- Update answers informations
UPDATE answers SET id = ?,  number = ?, name = ?)

-- Delete locations informations
DELETE FROM answers WHERE id = ? AND number = ? AND  name = ?)






