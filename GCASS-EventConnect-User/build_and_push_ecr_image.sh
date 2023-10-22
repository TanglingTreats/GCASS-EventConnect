#!/bin/bash
set -e

aws ecr get-login-password --region ap-southeast-1 --profile ballot-ecr-agent | docker login --username AWS --password-stdin 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com
docker build -f ./Dockerfile -t gcass-eventconnect-user:latest .
docker tag gcass-eventconnect-event:latest 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com/gcass-eventconnect-user:latest
docker push 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com/gcass-eventconnect-user:latest
