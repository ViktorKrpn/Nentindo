FROM node:19 as build

WORKDIR /app

COPY package*.json ./

RUN npm install

RUN npm install -g @angular/cli

COPY . .

RUN ng build --configuration=production

CMD ["ng", "serve", "--host", "0.0.0.0"]

#FROM nginx:latest


#COPY --from=build app/dist/angular/browser /usr/share/nginx/html

#EXPOSE 80


# docker build -t docker-angular .
# docker run -d -p 