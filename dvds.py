from flask import Flask, jsonify, request
import sqlite3
import json

version = "alpha"
endpoint = __name__
dbFile = __name__ + ".sqlite3"

app = Flask(endpoint)
db = sqlite3.connect(dbFile, check_same_thread=False)

def startDb():
  sql = None
  with open('dvds.sql', 'r', encoding='utf-8') as f:
    sql = f.read()
  print('sql:', sql)
  db.execute(sql)

startDb()


helloHelp = """Hello from dvds app v. {version}!

In order to publish a new DVD access the endpoint /{endpoint}
using a POST method and a json object like this:

<pre>
{jsonSample}
</pre>

Use case:
<pre>
curl -H "Content-Type: application/json" -d "@dvd.json" http://this-api-address/dvds
dvd criado com sucesso!
</pre>
"""


@app.route("/")
def hello():
  jsonSample = ""
  with open('dvd.json', 'r', encoding='utf-8') as f:
    jsonSample = f.read()
  ret = helloHelp.format(version=version, endpoint=endpoint, jsonSample=jsonSample)
  return ret


@app.route("/" + endpoint, methods=['POST'])
def register_dvd():
  dvd = request.get_json()
  columns = ['productTitle', 'images', 'qty', 'price', 'condition',
    'movieTrailer', 'delivery', 'takeout', 'warranty', 'format',
    'movieTitle', 'movieDirector', 'resolution', 'disks', 'audio',
    'gender', 'company']
  keys= tuple(dvd[c] for c in columns)
  cur = db.cursor()
  cur.execute('insert into dvds values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)', keys)
  db.commit()
  return "dvd " + str(cur.lastrowid) + " criado com sucesso!", 201

