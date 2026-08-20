
export default function toggleReducer({state,action}) {
    switch(action.type){
        case "turn on":
            return {status : true};
        case "turn off":
            return {status : false}
        default:
            return Error("Toggle is not wrong action")
        

    }
}
