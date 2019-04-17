import { SimpleCMSTemplatePage } from './app.po';

describe('SimpleCMS App', function() {
  let page: SimpleCMSTemplatePage;

  beforeEach(() => {
    page = new SimpleCMSTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
