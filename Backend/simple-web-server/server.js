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
<<<<<<< Updated upstream
    } catch (err) {
        console.error("Error connecting to the database:", err.message);
        throw err;
=======
    } catch (error) {
        console.error("Error connecting to the database:", error.message);
        throw error;
>>>>>>> Stashed changes
    }
}
//CREATE
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
<<<<<<< Updated upstream
    res.json(err);
=======
    res.json(error);
>>>>>>> Stashed changes
  }
});

//UPDATES
app.post("/user/update", async (req, res) => {
  try {
      const { name, age, email, gsm_number, code, consent } = req.body;

<<<<<<< Updated upstream
      if (!name || !age || !consent) {
=======
      if (!name || !age || !email || !code || !consent) {
>>>>>>> Stashed changes
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `UPDATE users SET name = ?, age = ?, 
      email = ?, gsm_number = ?, consent = ? WHERE code = ?`;
      await con.execute(query, [name, age, email, gsm_number, code, consent, code]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
<<<<<<< Updated upstream
    res.json(err);
=======
    res.json(error);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    res.json(err);
=======
    res.json(error);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    res.json(err);
=======
    res.json(error);
>>>>>>> Stashed changes
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
    res.status(500).json({ error: "Something went wrong." });
  }
});

<<<<<<< Updated upstream
=======
//SELECT
app.get("/users/:id", async (req, res) => {
  try {
    const { id, username, age, email, gsm_number, code, consent } = req.params; // Get the ID from the users table from the URL

    if (!id) {
      return res.status(400).json({ error: "Please select an existing ID in table users." });
    }

    const con = await connect();
    const query = "SELECT * FROM users WHERE id = ?, username = ?, age = ?, email = ?, gsm_number = ?, code = ?, consent = ?";
    const [result] = await con.execute(query, [id, username, age, email, gsm_number, code, consent ]); // Run the query

    await con.end();

    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "User not found." })
    }

    res.json({ message: "User found!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

app.get("/locations/:id", async (req, res) => {
  try {
    const { id, number, name } = req.params; // Get the ID from the users table from the URL

    if (!id) {
      return res.status(400).json({ error: "Please select an existing ID in table locations." });
    }

    const con = await connect();
    const query = "SELECT * FROM users WHERE id = ?, number = ?, name = ?";
    const [result] = await con.execute(query, [id, number, name]); // Run the query

    await con.end();

    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Location not found." })
    }

    res.json({ message: "Location found!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

app.get("/questions/:id", async (req, res) => {
  try {
    const { id, location_id, text } = req.params; // Get the ID from the users table from the URL

    if (!id) {
      return res.status(400).json({ error: "Please select an existing ID in table locations." });
    }

    const con = await connect();
    const query = "SELECT * FROM users WHERE id = ?, location_id = ?, text = ?";
    const [result] = await con.execute(query, [id, location_id, text]); // Run the query

    await con.end();

    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Question not found." })
    }

    res.json({ message: "Question found!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

app.get("/answers/:id", async (req, res) => {
  try {
    const { id, text, correct, question_id } = req.params; // Get the ID from the users table from the URL

    if (!id) {
      return res.status(400).json({ error: "Please select an existing ID in table locations." });
    }

    const con = await connect();
    const query = "SELECT * FROM users WHERE id = ?, text = ?, correct = ?, question_id = ?";
    const [result] = await con.execute(query, [id, text, correct, question_id]); // Run the query

    await con.end();

    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Answer not found." })
    }

    res.json({ message: "Answer found!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

>>>>>>> Stashed changes
// Start server
const PORT = process.env.PORT;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});
app.get("/", (req, res) => {
  res.send("WELKOM!!!");
<<<<<<< Updated upstream
});

=======
});
>>>>>>> Stashed changes
