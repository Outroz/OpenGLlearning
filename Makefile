MAKE=g++

main:
	$(MAKE) -g -o main.exe .\main.cpp stbImplementaition.cpp .\glad.c -lopengl32 -L"D:\Program Files\glfw-3.3.8-build\bin" -lglfw3 -I "D:\Program Files\glfw-3.3.8-build\include" -I "D:\Program Files\glad\include" -I "D:\Program Files\Test\include" -I "D:\GLM\glm"
