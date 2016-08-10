FROM higherknowledge/aspnet

# app
WORKDIR /app
COPY . /app
RUN echo '{"projects":["/packages"]}' > /app/global.json
RUN ["dnu", "restore"]

EXPOSE 6007
ENTRYPOINT ["dnx", "web"]

# vim: set filetype=dockerfile:
