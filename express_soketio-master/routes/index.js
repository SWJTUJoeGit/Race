var express = require('express');
var router = express.Router();
var mysql = require('mysql');

var conn = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '123456',
    port: 3007,
    database: 'Traffic_sign_GeoDatabase'
});

conn.connect();
/* GET home page. */
router.get('/', function(req, res, next) {
    var data = '';
    conn.query("SELECT * FROM test_board", function (err, rows, fields) {
        if(!err){

            data = JSON.stringify(rows);
            console.log(data);
            res.render('index', { title: 'Express', boards: data });
        }
    });

});

module.exports = router;
