//functions to pull data from wordle screen
//copy and paste into console to use
function readWordleKeyboard() {
    keyboardKeys = document.getElementsByClassName("Key-module_key__kchQI");
    ret = {
        "absentCharacters": [],
        "possibleCharacters": [],
        "correctCharacters": [],
    }
    for (let index = 0; index < keyboardKeys.length; index++) {
        let key = keyboardKeys[index].dataset["key"];
        let state = keyboardKeys[index].dataset["state"]
        if(key >= "a" && key <= "z"){
            if(state == "absent"){
                ret["absentCharacters"].push(key);
            }else if (state == "correct"){
                ret["correctCharacters"].push(key);
            }else{
                ret["possibleCharacters"].push(key);
            }
        }
    }
    console.log("absentCharacters:");
    console.log(ret["absentCharacters"]);
    console.log("possibleCharacters");
    console.log(ret["possibleCharacters"]);
    console.log("correctCharacters");
    console.log(ret["correctCharacters"]);
    return ret;
}

function getCorrectLocations(){
    word = ["*", "*", "*", "*", "*"]
    boardTiles = document.getElementsByClassName("Tile-module_tile__UWEHN");
    for (let index = 0; index < boardTiles.length; index++) {
        characterPosition = index % 5;
        currentTile = boardTiles[index];
        if(currentTile.dataset["state"] == "correct"){
            word[characterPosition] = currentTile.innerText.toLowerCase();
        }
    }

    return word.join("")
}

wordleData = readWordleKeyboard();
correctCharacterLocations = getCorrectLocations();
