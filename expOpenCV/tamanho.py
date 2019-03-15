# _*_ coding: utf-8 _*_
# Importa os pacotes necessários
from scipy.spatial import distance as dist
from imutils import perspective
from imutils import contours
import numpy as np
import argparse
import imutils
import cv2

def midpoint(ptA, ptB):
	return ((ptA[0] + ptB [0]) * 0.5, (ptA[1] + ptB[1]) * 0.5)
	

# Realiza a interpretacao dos parametros de entrada
ap = argparse.ArgumentParser()
ap.add_argument("-i", "--image", required=True, help="caminho para o arquivo de imagem")
ap.add_argument("-w", "--width", type=float, required=True, help="largura do objeto mais à esquerda em centímetros")
args = vars(ap.parse_args())

# Carrega a imagem, converte para escala de cinza e a desfoca ligeiramente
image = cv2.imread(args["image"])
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
gray = cv2.GaussianBlur(gray, (7, 7), 0)

# Detecta de bordas, então relaiza dilatação e erosão para
# fechar os intervalos entre bordas
edged = cv2.Canny(gray, 50, 100)
edged = cv2.dilate(edged, None, iterations=1)
edged = cv2.erode(edged, None, iterations=1)

# Encontra os contornos no mapa
cnts = cv2.findContours(edged.copy(), cv2.RETR_EXTERNAL, 
	cv2.CHAIN_APPROX_SIMPLE)
cnts = imutils.grab_contours(cnts)

# Organiza os contornos da direita para a esquerda e inicializa a variável
# pixels por cm
(cnts, _) = contours.sort_contours(cnts)
pixelsPerMetric = None

# Loop através dos contornos encontrados
for c in cnts:
	# Ignora contornos pequenos demais
	if cv2.contourArea(c) < 100:
		continue
		
	# Computa a moldura rotacionada do contorno
	orig = image.copy()
	box = cv2.minAreaRect(c)
	box = cv2.cv.BoxPoints(box) if imutils.is_cv2() else cv2.boxPoints(box)
	box = np.array(box, dtype="int")
	
	# Ordena os pontos no contorno de forma em que eles apareçam na ordem
	# superior esquerdo, superior direito, inferior direito, inferior esquerdo
	# então desenha a linha da moldura externa rotacionada
	box = perspective.order_points(box)
	cv2.drawContours(orig, [box.astype("int")], -1, (0, 255, 0), 2)
	
	# Loop pelos pontos originais para desenhá-los
	for (x, y) in box:
		cv2.circle(orig, (int(x), int(y)), 5, (0, 0, 255), -1)
	
	#
	(tl, tr, br, bl) = box
	(tltrX, tltrY) = midpoint(tl, tr)
	(blbrX, blbrY) = midpoint(bl, br)
	
	#
	(tlblX, tlblY) = midpoint(tl, bl)
	(trbrX, trbrY) = midpoint(tr, br)
	
	#
	cv2.circle(orig, (int(tltrX), int(tltrY)), 5, (255, 0, 0), -1)
	cv2.circle(orig, (int(blbrX), int(blbrY)), 5, (255, 0, 0), -1)
	cv2.circle(orig, (int(tlblX), int(tlblY)), 5, (255, 0, 0), -1)
	cv2.circle(orig, (int(trbrX), int(trbrY)), 5, (255, 0, 0), -1)
	
	#
	cv2.line(orig, (int(tltrX), int(tltrY)), (int(blbrX), int(blbrY)), (255, 0, 255), 2)
	cv2.line(orig, (int(tlblX), int(tlblY)), (int(trbrX), int(trbrY)), (255, 0, 255), 2)
	
	#
	da = dist.euclidean((tltrX, tltrY), (blbrX, blbrY))
	db = dist.euclidean((tlblX, tlblY), (trbrX, trbrY))
	
	#
	if pixelsPerMetric is None:
		pixelsPerMetric = db / args["width"]
		
	# Computa o tamanho do objeto
	dimA = da / pixelsPerMetric
	dimB = db / pixelsPerMetric
	
	# Desenha os tamanhos dos objetos na imagem
	cv2.putText(orig, "{:.1f}cm".format(dimA), (int(tltrX - 15), int(tltrY -10)), cv2.FONT_HERSHEY_SIMPLEX, 0.65, (255, 255, 255), 2)
	cv2.putText(orig, "{:.1f}cm".format(dimB), (int(trbrX - 15), int(trbrY -10)), cv2.FONT_HERSHEY_SIMPLEX, 0.65, (255, 255, 255), 2)

	# Exibe a imagem final
	cv2.imshow("Image", orig)
	cv2.waitKey(0)
