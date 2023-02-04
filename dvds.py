# hello.py

from flask import Flask, jsonify, request


endpoint = __name__
app = Flask(endpoint)
version = "alpha"

helloHelp = """Hello from dvds app v. {version}!

In order to publish a new DVD access the endpoint /{endpoint}
using a POST method and a json object like this:

<pre>
{jsonSample}
</pre>

Use case:
<pre>
curl -H "application/json" -d "@dvd.json" http://this-api-address/dvds
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

@app.route('/dvds', methods=['POST'])
def register_dvd():
  return request.get_json(), 204

