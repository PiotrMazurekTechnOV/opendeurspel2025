const express = require("express");
const app = express();
const mysql = require("mysql2/promise");
const bodyParser = require("body-parser");
require('dotenv').config()

// Middleware
app.use(express.json());
app.use(bodyParser.json());

// Database connection 
async function connect() {
    try {
        return await mysql.createConnection({
            host: process.env.HOST,
            user: process.env.USER,
            password: process.env.PASSWORD,
            database: process.env.DB,
        });
    } catch (err) {
        console.error("Error connecting to the database:", err.message);
        throw err;
    }
}
//CREATE
//user
app.post("/user/create", async (req, res) => {
  try {
      const { name, age, email, gsm_number, code, consent } = req.body;

      if (!name || !age || !gsm_number ||!consent) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (name, age, email, gsm_number, code, consent) VALUES 
      (?, ?, ?, ?, ?, ?)`;
      await con.execute(query, [name, age, email, gsm_number, code, consent]);

      await con.end(); 
      res.status(201).json({ message: "User created successfully!" });
  } catch (error) {
    res.json(err);
  }
});
//questions
app.post("/question/create", async (req, res) => {
  try {
      const { location_id, text } = req.body;

      if (!location_id || !text) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (location_id, text) VALUES 
      (?, ?)`;
      await con.execute(query, [location_id, text]);

      await con.end(); 
      res.status(201).json({ message: "Question created successfully!" });
  } catch (error) {
    res.json(err);
  }
});
//answers
app.post("/answers/create", async (req, res) => {
  try {
      const { text, correct, question_id } = req.body;

      if (!text || !correct ||!question_id) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (text, correct, question_id) VALUES 
      (?, ?, ?)`;
      await con.execute(query, [text, correct, question_id]);

      await con.end(); 
      res.status(201).json({ message: "Answer created successfully!" });
  } catch (error) {
    res.json(err);
  }
});
//locations
app.post("/locations/create", async (req, res) => {
  try {
      const { number, name } = req.body;

      if (!number || !name) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (number, name) VALUES 
      (?, ?)`;
      await con.execute(query, [number, name]);

      await con.end(); 
      res.status(201).json({ message: "Location created successfully!" });
  } catch (error) {
    res.json(err);
  }
});
//scores
app.post("/scores/create", async (req, res) => {
  try {
      const { user_id, question_id, correct } = req.body;

      if (!user_id || !question_id ||!correct) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (user_id, question_id, correct) VALUES 
      (?, ?, ?)`;
      await con.execute(query, [user_id, question_id, correct]);

      await con.end(); 
      res.status(201).json({ message: "Scores created successfully!" });
  } catch (error) {
    res.json(err);
  }
});

//UPDATES
app.post("/user/update", async (req, res) => {
  try {
      const { name, age, email, gsm_number, code, consent } = req.body;

      if (!name || !age || !consent) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `UPDATE users SET name = ?, age = ?, 
      email = ?, gsm_number = ?, consent = ? WHERE code = ?`;
      await con.execute(query, [name, age, email, gsm_number, code, consent, code]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(err);
  }
});

app.post("/location/update", async (req, res)=>{
  try {
    const { number, name} = req.body;
    if(!number || !name) {
      return res.status(400).json({error: "All fields are required."});
    }
    const con = await connect(); 
      const query = `UPDATE locations SET name = ? WHERE number = ?`;
      await con.execute(query, [name, number]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(err);
  }}
);

app.post("/question/update", async (req, res)=>{
  try {
    const { location_id, text} = req.body;
    if(!location_id || !text) {
      return res.status(400).json({error: "All fields are required."});
    }
    const con = await connect(); 
      const query = `UPDATE questions SET text = ? WHERE location_id = ?`;
      await con.execute(query, [location_id, text]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(err);
  }}
);
// DELETE 
app.delete("/question/:id", async (req, res) => {
  try {
    const { id } = req.params; // Get the question ID from the URL

    if (!id) {
      return res.status(400).json({ error: "Please provide a question ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM questions WHERE id = ?"; 
    const [result] = await con.execute(query, [id]); // Run delete query

    await con.end(); 
    
    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Question not found." });
    }

    res.json({ message: "Question deleted successfully!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong with the server" });
  }
});

//READ
//Read question
app.get("/question/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; // Get the question ID from the URL

    if (!id) {
      return res.status(400).json({ error: "Please provide a question ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM questions WHERE id = ?";
    
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); 

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Question not found." });
    }

    res.json({ message: "Question read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});
//Read users
app.get("/users/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a user ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM users WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "User not found." });
    }

    res.json({ message: "User read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});
//Read answers
app.get("/answers/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide an answer ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM answers WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Answer not found." });
    }

    res.json({ message: "Answer read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});
//Read Locations
app.get("/locations/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a location ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM locations WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Location not found." });
    }

    res.json({ message: "Location read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});
//Read scores
app.get("/scores/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a score ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM scores WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: " not found." });
    }

    res.json({ message: "User read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

// Start server
const PORT = process.env.PORT;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});
app.get("/", (req, res) => {
  res.send("WELKOM!!!");
});

