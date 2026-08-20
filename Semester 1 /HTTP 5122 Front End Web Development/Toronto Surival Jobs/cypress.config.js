const { defineConfig } = require("cypress");

module.exports = defineConfig({
  projectId: 'x49z3y',
  allowCypressEnv: false,

  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
