# Introduction

This is an API to register new DVDs to sell on MercadoLivre.

# How to run

This API depends on:

 - Python 3;
 - Flask (pip install flask).

With all dependencies available run the following commands inside a terminal:

```
set FLASK_APP=dvds.py
flask run
```

# Endpoints

## /

Prints the help to how to register a DVD.

## /api/dvds

### GET

List all DVDs registered. Eg:

```
curl http://localhost:5000/api/dvds/
```

### POST

Register a new DVD. Eg:

```
curl -H "Content-Type: application/json" -d "@dvd.json" http://localhost:5000/api/dvds/
```
