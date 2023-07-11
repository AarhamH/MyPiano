import { TypeTesterTemplatePage } from './app.po';

describe('TypeTester App', function() {
  let page: TypeTesterTemplatePage;

  beforeEach(() => {
    page = new TypeTesterTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
