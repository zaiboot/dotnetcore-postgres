import { PrizeInfo, Status } from './prize-info';

describe('PrizeInfo', () => {
  it('should create an instance', () => {
    expect(new PrizeInfo(Status.Available,"descr",123)).toBeTruthy();
  });
});
