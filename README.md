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

## /dvds

Allows you to register a new DVD using POST method.
