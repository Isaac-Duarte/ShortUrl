#!/bin/bash
if [ "$(uname)" == "Darwin" ]; then
    clipboard="$(pbpaste)"
    orginalUrl=$(curl -X POST --data '{"url": "'"$clipboard"'"}' -H "Content-Type: application/json" https://fozie.net)
    echo $orginalUrl | pbcopy
elif [ "$(expr substr $(uname -s) 1 5)" == "Linux" ]; then
    clipboard="$(xclip -o)"
    orginalUrl=$(curl -X POST --data '{"url": "'"$clipboard"'"}' -H "Content-Type: application/json" https://fozie.net)
    echo $orginalUrl | xclip -sel clip   
fi