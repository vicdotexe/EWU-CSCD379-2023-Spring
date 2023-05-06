<template>
  <header class="d-flex justify-space-between">
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
        <RouterLink to="/about">About</RouterLink>
      </nav>
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
    </div>
    Logged in as <ActiveUser/>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import ActiveUser from './components/ActiveUser.vue'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
</script>
