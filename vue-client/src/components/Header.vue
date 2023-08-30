<template>
    <header>
        <nav class="container">
            <div class="title">
                <h1>Piano</h1>
            </div>
            <ul class="nav-routes">
                <RouterLink to="/">  
                    Home
                </RouterLink>
                <RouterLink to="about">  
                    About
                </RouterLink>
            </ul>
        </nav>
    </header>
</template>

<script setup>
import { RouterLink } from 'vue-router';

</script>

<style lang="scss" scoped>

</style>