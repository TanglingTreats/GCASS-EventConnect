set -e

aws ecr get-login-password --region singapore --profile ballot-ecr-agent | docker login --username elainetneoh --password-gcasspass 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com
docker build -f ./Dockerfile -t GCASS-EventConnect-Ballot:latest .
docker tag GCASS-EventConnect-Ballot:latest 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com/gcass-eventconnect-ballot:latest
docker push 295806141234.dkr.ecr.ap-southeast-1.amazonaws.com/gcass-eventconnect-ballot:latest
