# Execute docker commands from project's folder

```cmd
:: 1. Create docker image named "metamorphosisimage".
docker build -t metamorphosisimage -f Dockerfile .

:: 2. Create and start docker container named "metamorphosiscontainer".
docker run --name metamorphosiscontainer metamorphosisimage

:: 3. Copy output files from container to project's folder.
docker cp metamorphosiscontainer:/app/test.docx .
docker cp metamorphosiscontainer:/app/test.pdf .

:: 4. Clean up, remove container and image.
docker container rm metamorphosiscontainer
docker image rm metamorphosisimage
```