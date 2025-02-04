// Import the necessary modules
const express = require('express');
const mysql = require('mysql2');

// Create a connection to the database
const connection = MySQL.createConnection({
  host: process.env.HOST,
  user: process.env.USER,
  password: process.env.PASSWORD,
  database: process.env.DB
});

// Connect to the database
connection.connect((err) => {
  if (err) {
    console.error('Error connecting to database: ', err);
    return;
  }
  console.log('Connected to database!');

  // Create a new user
  var userID = 1;
  var userName = 'Alexxo';
  var userAge = 30;
  var userEmail = 'alexi.alexi@gmail.com';
  var userGsm_number = "0456078905";
  var userCode = 345;
  var userConsent = 1; // 1 for true, 0 for false
  const query = `
    INSERT INTO users (id, name, age, email, gsm_number, code, consent)
    VALUES (?, ?, ?, ?, ?, ?, ?)
  `;

  connection.query(query, [userID, userName, userAge, userEmail, userGsm_number, userCode, userConsent], (err, result) => {
    if (err) {
      console.error('Error Creating user: ', err);
      return;
    }

    console.log('User Created successfully!');
    
  });
  // Delete a user by ID
  var userId = 1;

  query2 = `
    DELETE FROM users
    WHERE id = ?
  `;
  

  connection.query2(query2, [userID, userName, userAge, userEmail, userGsm_number, userCode, userConsent], (err, result) => {
    if (err) {
      console.error('Error Deleting user: ', err);
      return;
    }

    console.log('User Deleted successfully!');

    
  });
  // Update a user's information
  var userID = 1;
  var newName = 'Alexxxo';
  var newAge = 30;
  var newEmail = 'alexi.alexi@gmail.com';
  var userGsm_number = "0457897895";
  var userCode = 234;
  var newConsent = 1; // 1 for true, 0 for false
  const query3 = `
    UPDATE users
    SET name = ?,
        age = ?,
        email = ?,
        gsm_number = ?,
        code = ?;
        consent = ?
    WHERE id = ?
  `;
  connection.query3(query3, [userID, newName, newAge, newEmail, newConsent], (err, result) => {
    if (err) {
      console.error('Error Updating user: ', err);
      return;
    }

    console.log('User Updated successfully!');

    
  });

  // Close the database connection
  connection.end();
});