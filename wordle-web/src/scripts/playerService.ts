import {ref} from 'vue'
import Axios from 'axios';

const playerId = ref<string|null>(localStorage.getItem('userId'));
const playerName = ref<string>("Guest");

export const Player = {
    GetId: () => playerId.value,
    SetId: (id: string) => {localStorage.setItem('userId', id); playerId.value = id},
    GetName: () => playerName.value,
    SetName: (name: string) => playerName.value = name
  }

  const CreatePlayer = async() =>{
    var response = await Axios.post('/player');
    var id = response.data.playerId;
    Player.SetId(id);
  }
  
  const SetPlayer = async() =>{
    var response = await Axios.get(`/player?id=${Player.GetId()}`);
    if (response.status == 200){
      Player.SetName(response.data.name);
    } else {
      CreatePlayer();
    }
  }

  export const SyncPlayerAsync = async() => {
    if (!Player.GetId()){
        await CreatePlayer();
      } else {
        await SetPlayer();
      }
  }