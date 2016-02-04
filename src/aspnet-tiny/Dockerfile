FROM iron/base

RUN echo '@edge http://nl.alpinelinux.org/alpine/edge/main' >> /etc/apk/repositories
RUN echo '@community http://nl.alpinelinux.org/alpine/edge/community' >> /etc/apk/repositories
RUN echo '@testing http://nl.alpinelinux.org/alpine/edge/testing' >> /etc/apk/repositories
RUN apk update && apk upgrade

RUN apk add --update bash

ENV DNX_VERSION 1.0.0-rc1-update1
ENV DNX_USER_HOME /opt/DNX_BRANCH
ENV DNX_RUNTIME_ID ironbase

# Is it needed?
RUN echo > ~/.bash_profile
RUN echo > ~/.profile

RUN apk add unzip curl gettext
#libcurl libunwind openssl-dev gnutls  sqlite zlib
# These package is not curretnly available on alpine 
#  libcurl3-gnutls   sqlite3 libsqlite3-dev libunwind8 libicu-dev zlib1g

RUN curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_USER_HOME=$DNX_USER_HOME DNX_BRANCH=v$DNX_VERSION sh
RUN bash -c "source $DNX_USER_HOME/dnvm/dnvm.sh \
	&& dnvm install $DNX_VERSION -alias default -r coreclr \
	&& dnvm alias default | xargs -i ln -s $DNX_USER_HOME/runtimes/{} $DNX_USER_HOME/runtimes/default"

RUN chmod 755 $DNX_USER_HOME/dnvm/dnvm.sh

ENV PATH $PATH:$DNX_USER_HOME/runtimes/default/bin

# Clean APK cache
RUN rm -rf /var/cache/apk/*
#ENTRYPOINT /bin/sh -c 'curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_USER_HOME=$DNX_USER_HOME DNX_BRANCH=v$DNX_VERSION sh && source $DNX_USER_HOME/dnvm/dnvm.sh'