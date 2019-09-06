import { PrizeInfo, Status } from './models/prize-info';

describe('PrizeInfo', () => {
  it('should create an instance', () => {
    expect(new PrizeInfo(Status.Available,"descr",123)).toBeTruthy();
  });
});
