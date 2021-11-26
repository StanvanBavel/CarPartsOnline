// sample_spec.js created with Cypress
//
// Start writing your Cypress tests below!
// If you're unfamiliar with how Cypress works,
// check out the link below and learn how to write your first test:
// https://on.cypress.io/writing-first-test

describe('My First Test', () => {
    it('Does not do much!', () => {
        expect(true).to.equal(true)
    })
});

// describe('My First Test', () => {
//     it('Does not do much!', () => {
//         expect(true).to.equal(false)
//     })
// })

describe('Click to ProductPage', () => {
    it('clicks the link "Product"', () => {
        cy.visit('http://localhost:8080');

        cy.contains('Products').click();

        cy.url().should('include', '/products');

        // cy.get('#app > div >  router-link > div> img> div> h5> h6> p> a> ').click();

        cy.contains('Products');
       

        // cy.get('.custom-select').click()
    })
})


