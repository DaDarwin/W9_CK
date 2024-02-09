<template>
  <span class="navbar-text">
    <button class="btn selectable text-success lighten-30 text-uppercase my-2 my-lg-0" @click="login"
      v-if="!user.isAuthenticated">
      Login
    </button>
    <span v-else>
      <section class="dropdown my-2 my-lg-0">

          <span v-if="account.picture || user.picture" type="button" class="border-0 selectable no-select" data-bs-toggle="dropdown" aria-expanded="false">
            <img :src="account.picture || user.picture" alt="account photo" height="40" class="rounded-circle" />
          </span>
        <span class="dropdown-menu dropdown-menu-sm-end dropdown-menu-start p-0" aria-labelledby="authDropdown">
          <span class="list-group">
            <router-link :to="{ name: 'Account' }">
              <span class="list-group-item dropdown-item list-group-item-action">
                Manage Account
              </span>
            </router-link>
            <span class="list-group-item dropdown-item list-group-item-action text-danger selectable" @click="logout">
              <i class="mdi mdi-logout"></i>
              logout
            </span>
          </span>
        </span>
      </section>
    </span>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style lang="scss" scoped></style>
