from openpyxl import load_workbook
workbook = load_workbook(filename="Anunciar-02-01-11_03_16.xlsx")
sheet = workbook['Filmes']

class Movie:
	def __init__(self):
		self.productTitle = ""
		self.images = ""
		self.qty = 1
		self.price = "12,99"
		self.condition = "Usado"
		self.movieTrailer = ""
		self.delivery = "Por conta do comprador"
		self.takeout = "Aceito"
		self.warranty = "Sem garantia"
		self.format = "DVD"
		self.movieTitle = ""
		self.movieDirector = ""
		self.resolution = "SD"
		self.disks = 1
		self.audio = "Inglês"
		self.gender = "Drama"
		self.company = "Paramount"
		self.format = "Físico"

def WriteMovieToSheet(sheet, line, movie):
	sheet["A" + str(line)] = movie.productTitle
	sheet["D" + str(line)] = movie.images
	sheet["F" + str(line)] = movie.qty
	sheet["G" + str(line)] = movie.price
	sheet["H" + str(line)] = movie.condition
	sheet["J" + str(line)] = movie.movieTrailer
	sheet["N" + str(line)] = movie.delivery
	sheet["O" + str(line)] = movie.takeout
	sheet["P" + str(line)] = movie.warranty
	sheet["S" + str(line)] = movie.format
	sheet["T" + str(line)] = movie.movieTitle
	sheet["U" + str(line)] = movie.movieDirector
	sheet["V" + str(line)] = movie.resolution
	sheet["W" + str(line)] = movie.disks
	sheet["X" + str(line)] = movie.audio
	sheet["Y" + str(line)] = movie.gender
	sheet["Z" + str(line)] = movie.company
	sheet["AA" + str(line)] = movie.format

movie = Movie()
for i in range(6, 36, 1):
	WriteMovieToSheet(sheet, i, movie)

workbook.save("Test.xlsx")

