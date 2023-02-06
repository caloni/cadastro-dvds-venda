from flask import Flask, jsonify, render_template, request, send_file,url_for,flash,redirect
import sqlite3
import json
import spreadsheet
import io

version = "alpha"
endpoint = "dvds"
dbFile = endpoint + ".sqlite3"

app = Flask(endpoint)
# Make the WSGI interface available at the top level so wfastcgi can get it.
wsgi_app = app.wsgi_app
db = sqlite3.connect(dbFile, check_same_thread=False)

def startDb():
  def row_to_dict(cursor: sqlite3.Cursor, row: sqlite3.Row) -> dict:
    data = {}
    for idx, col in enumerate(cursor.description):
      data[col[0]] = row[idx]
    return data

  db.row_factory = row_to_dict

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


@app.route("/" + endpoint, methods=['GET', 'POST'])
def register_dvd():
  if request.method=='GET':
    sp = spreadsheet.Load()
    cur = db.cursor()
    cur.execute('select * from dvds')
    rows = cur.fetchall()
    line = 0
    for row in rows:
      spreadsheet.Write(sp, row, line)
      line = line + 1
    path = spreadsheet.Save(sp)
    with open(path, 'rb') as bytes:
      return send_file(io.BytesIO(bytes.read()), download_name='dvds.xlsx', mimetype='application/vnd.openxmlformats-officedocument.spreadsheetml.sheet')
  elif request.method=='POST':
    dvd = request.get_json()
    columns = ['productTitle', 'images', 'qty', 'price', 'condition',
      'movieTrailer', 'delivery', 'takeout', 'warranty', 'movieFormat',
      'movieTitle', 'movieDirector', 'resolution', 'disks', 'audio',
      'gender', 'company', 'format']
    keys= tuple(dvd[c] for c in columns)
    cur = db.cursor()
    cur.execute('insert into dvds values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)', keys)
    db.commit()
    return "dvd " + str(cur.lastrowid) + " criado com sucesso!", 201


@app.route("/add_dvd",methods=['POST','GET'])
def add_dvd():
    if request.method=='POST':
      fields = (request.form['productTitle'], request.form['images'], request.form['qty'],
        request.form['price'], request.form['condition'], request.form['movieTrailer'],
        request.form['delivery'], request.form['takeout'], request.form['warranty'],
        request.form['movieFormat'], request.form['movieTitle'], request.form['movieDirector'],
        request.form['resolution'], request.form['disks'], request.form['audio'],
        request.form['gender'], request.form['company'], request.form['format'])
      cur = db.cursor()
      cur.execute('insert into dvds values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)', fields)
      db.commit()
      flash("dvd " + str(cur.lastrowid) + " criado com sucesso!",'success')
      return redirect(url_for("add_dvd"))
    return render_template("add_dvd.html")


if __name__ == '__main__':
    import os
    HOST = os.environ.get('SERVER_HOST', '0.0.0.0')
    try:
        PORT = int(os.environ.get('SERVER_PORT', '5000'))
    except ValueError:
        PORT = 5000
    app.secret_key='admin123'
    #app.run(debug=True)
    app.run(HOST, PORT)

