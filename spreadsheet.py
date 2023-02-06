from openpyxl import load_workbook


def Load():
  return load_workbook(filename="Anunciar-02-01-11_03_16.xlsx")


def Save(spreadsheet):
  spreadsheet.save("Temp.xlsx")
  return "Temp.xlsx"


def Write(spreadsheet, dvd, line):
  sheet = spreadsheet['Filmes']
  line = line + 6
  sheet["A" + str(line)] = dvd[0] # productTitle
  sheet["D" + str(line)] = dvd[1] # images
  sheet["F" + str(line)] = dvd[2] # qty
  sheet["G" + str(line)] = dvd[3] # price
  sheet["H" + str(line)] = dvd[4] # condition
  sheet["J" + str(line)] = dvd[5] # movieTrailer
  sheet["N" + str(line)] = dvd[6] # delivery
  sheet["O" + str(line)] = dvd[7] # takeout
  sheet["P" + str(line)] = dvd[8] # warranty
  sheet["S" + str(line)] = dvd[9] # movieFormat
  sheet["T" + str(line)] = dvd[10] # movieTitle
  sheet["U" + str(line)] = dvd[11] # movieDirector
  sheet["V" + str(line)] = dvd[12] # resolution
  sheet["W" + str(line)] = dvd[13] # disks
  sheet["X" + str(line)] = dvd[14] # audio
  sheet["Y" + str(line)] = dvd[15] # gender
  sheet["Z" + str(line)] = dvd[16] # company
  sheet["AA" + str(line)] = dvd[17] # format

