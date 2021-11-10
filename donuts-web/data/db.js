const MongoClient = require('mongodb').MongoClient;
const { DONUT_DBHOST, DONUT_DBNAME, DONUT_DBUSER, DONUT_DBPWD } = require('../env').db;

let db;

const loadDatabase = async () => {
    if (db) { return db; }
    try {
        const client = await MongoClient.connect(`mongodb+srv://${DONUT_DBUSER}:${DONUT_DBPWD}@${DONUT_DBHOST}/${DONUT_DBNAME}`, {
            useNewUrlParser: true,
            useUnifiedTopology: true
        });
        db = client.db(DONUT_DBNAME);
    } catch (err) {
        console.log(err);
    }
    return db;
}

module.exports = loadDatabase;
