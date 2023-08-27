import pickle
import tensorflow as tf
import os
import cv2
import numpy as np
from tensorflow.keras.models import load_model
import re
import sys
ar=sys.argv[1]
model=load_model('fin.h5')
dir="D:\\deep learning\\dataset\\train\\"
cat=os.listdir(dir)
im=cv2.imread(ar)
im=cv2.resize(im,(200,200))
im=im.reshape(1,200,200,3)
im=im/255.0
p=model.predict([im])
p=np.ndarray.tolist(p.reshape(-1,1))
i=p.index(max(p))
text_file = open("Output.txt", "w")
text_file.write(cat[i])
text_file.close()


